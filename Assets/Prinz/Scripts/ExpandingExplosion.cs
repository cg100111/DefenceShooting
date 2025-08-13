using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject shotGenerator;

    [SerializeField] private float MAXRADIUS = 10.0f;
//  [SerializeField] private float MINRADIUS = 0.0f;
//  [SerializeField] private float expandingSpeed = 0.0f;
    [SerializeField] private float MAXTIMER = 0.0f;

    private float timer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = 0.5f;  // 50%の透明性
        sr.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.timer < MAXTIMER)
        {
            this.timer += Time.deltaTime;
            float t = Mathf.Clamp01(this.timer / MAXTIMER);
            float eased = EaseOutQuint(t);
            float scale = Mathf.Lerp(1f, MAXRADIUS, eased);
            transform.localScale = new Vector3(scale, scale, 0.0f);
        }
        else
        {
            this.timer = 0.0f;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //当たり判定
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                int randSize = Random.Range(15, 50);
                explosionPrefab.transform.localScale = new Vector3(randSize, randSize, 0);
                Instantiate(explosionPrefab, collision.transform.position, this.transform.rotation);
                Debug.Log("Hit !");
            }
        }
    }

    float EaseOutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 5);
    }

}
