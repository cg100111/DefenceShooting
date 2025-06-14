using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shot1Script : MonoBehaviour
{
    float timer = 0.0f; //bullet timer
    const float MAXTIMER = 10.0f; //bullet max timer
    public AudioClip[] SEbounce;
    AudioSource aud;

    [SerializeField]
    private int damageValue = 2;
    [SerializeField]
    private int bounceCnt = 1;

   // public int DV = 2;

    private ShotGenerator generator;
    public GameObject ExplosionPrefab;

    public void SetGenerator(ShotGenerator gen)
    {
        generator = gen;
    }
    public void Shoot(Vector3 dir, float spin)
    {
        Vector2 dir2D = new Vector2(dir.x, dir.y);
        GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddTorque(spin, ForceMode2D.Impulse);
        this.damageValue =  1 + (int)spin / 3;

        Debug.Log($"Damage Value : {this.damageValue}"); //debug

        this.aud = GetComponent<AudioSource>();
        //   Debug.Log($"dir : {dir}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boundaries"))
        {
            // Optional: Knockback (example, simple force away from bullet)
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 knockback = collision.transform.position - transform.position;
                rb.AddForce(knockback.normalized * 10000f); // adjust force value
                if (this.bounceCnt <= 0)
                {
                 //   ShotExplosion shotExplosion = GetComponent<ShotExplosion>();
                    //    shotExplosion.EffectExplosion(gameObject.transform.position);
                    Instantiate(ExplosionPrefab, this.transform.position, ExplosionPrefab.transform.rotation);

                    generator?.PlaySEexplosion(); // play SE safely
                    // Destroy bullet
                    Destroy(gameObject);
                }
                else
                {
                    this.bounceCnt--;
                    int randomSE = Random.Range(0, SEbounce.Length); // Random index 0 to 2
                    aud.PlayOneShot(SEbounce[randomSE]);
                }
            }

        }
        //else if (collision.gameObject.CompareTag("Boundaries"))
        //{
        //    Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        //    if (rb != null)
        //    {
        //        if (this.bounceCnt <= 0)
        //        {
        //            Destroy(gameObject);
        //        }
        //        else
        //        {
        //            this.bounceCnt--;
        //        }
        //    }
        //}
    }


    public int GetDamageValue()
    {
        return damageValue;
    }

    public int GetBounceCnt()
    {
        return this.bounceCnt;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if(timer >= MAXTIMER)
        {
            timer = 0.0f;
            Destroy(gameObject);
        }
    }
}
