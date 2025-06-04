using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public void Shoot(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir);
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
