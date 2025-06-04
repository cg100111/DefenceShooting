using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGenerator : MonoBehaviour
{
    public GameObject Shot1Prefab;
   // public GameObject ShotGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate(Shot1Prefab);

            // Get the point at Z = 50 in world space under the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 50f; // distance from camera (not world Z)

            Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);

            GameObject shotgen = GameObject.Find("ShotGenerator");
            shot.transform.position = shotgen.transform.position + shotgen.transform.forward * 1.0f;

            // Compute the direction from shot origin to the fixed-Z point
            Vector3 worldDir = (targetPos - shot.transform.position).normalized;

            // Shoot in that direction
            shot.GetComponent<Shot1Script>().Shoot(worldDir * 2000);
        }

    }
}

