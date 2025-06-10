using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot1Script : MonoBehaviour
{
    float timer = 0.0f; //bullet timer
    const float MAXTIMER = 10.0f; //bullet max timer
    public int damageValue = 2; //bullet damage
    public void Shoot(Vector3 dir, float spin)
    {
        Vector2 dir2D = new Vector2(dir.x, dir.y);
        GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddTorque(spin, ForceMode2D.Impulse);


     //   Debug.Log($"dir : {dir}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage
            collision.gameObject.GetComponent<Enemy>().ReduceHP(damageValue);

            // Optional: Knockback (example, simple force away from bullet)
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 knockback = collision.transform.position - transform.position;
                rb.AddForce(knockback.normalized * 1000f); // adjust force value
            }

            // Destroy bullet (unless you want it to bounce)
         //   Destroy(gameObject);
        }
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        //    collision.gameObject.GetComponent<GameObject>().HP -= Mathf.Min(1.0f, damageValue);
    //        Debug.Log("Bullet has hit");
    //        Destroy(gameObject);
    //    }
    //}

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
