using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot1Script : MonoBehaviour
{
    float timer = 0.0f;
    const float MAXTIMER = 3.0f;
    public void Shoot(Vector3 dir, float spin)
    {
        Vector2 dir2D = new Vector2(dir.x, dir.y);
        GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddTorque(spin, ForceMode2D.Impulse);


     //   Debug.Log($"dir : {dir}");
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
