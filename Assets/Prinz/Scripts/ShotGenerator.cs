using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ShotGenerator : MonoBehaviour
{
    public GameObject Shot1Prefab;
    public Slider chargeBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChargeAndFire());
            Test();
        }
    }


    IEnumerator ChargeAndFire()
    {
        float power = 0.0f;
        chargeBar.gameObject.SetActive(true); // show bar


        while (Input.GetMouseButton(0))
        {
            power += Time.deltaTime;
            chargeBar.value = power;
            if (power >= 3.0f)
            {
            //    chargeBar.value = 3.0f;
                break;
            }
            yield return null; // wait for next frame
        }

        chargeBar.value = 0;
        chargeBar.gameObject.SetActive(false); // hide bar
        // Find the shot generator
        GameObject shotgen = GameObject.Find("ShotGenerator");

        


        // Set spawn position slightly in front of the generator
     //   UnityEngine.Vector3 spawnPos = shotgen.transform.position + shotgen.transform.forward * 1.0f;
    //    spawnPos.z = 50f; // force Z to exactly 50
    //    shot.transform.position = spawnPos;

        // Create a normal pointing forward (Z), then rotate it 10° around X
        //    UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(10.0f, 0.0f, 0.0f);
        //   UnityEngine.Vector3 rotatedNormal = rotation * UnityEngine.Vector3.forward;

        // Define the rotated plane at world Z = 50
        //     UnityEngine.Plane tiltedPlane = new UnityEngine.Plane(rotatedNormal, new UnityEngine.Vector3(0.0f, 0.0f, 50.0f));

        // Cast a ray from the mouse position
        //   RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), UnityEngine.Vector2.zero);

        UnityEngine.Vector3 mp = Input.mousePosition;
        mp.z = 60.0f - Camera.main.transform.position.z;
        UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(mp);
        worldPos.z = 60.0f;
        UnityEngine.Vector3 bulletSpawnPos = shotgen.transform.position;
        // Instantiate the shot
        GameObject shot = Instantiate(Shot1Prefab, bulletSpawnPos, UnityEngine.Quaternion.identity);
        shot.GetComponent<Shot1Script>().Shoot((worldPos - bulletSpawnPos).normalized * (1 + power * 50), power * 15);

        Debug.Log($"worldPos : {worldPos}");
        Debug.Log($"bullSpanPos : {bulletSpawnPos}");
        Debug.Log($"distance : {worldPos - bulletSpawnPos}");
        Debug.Log($"distance norm : {(worldPos - bulletSpawnPos).normalized}");
        /*       if (tiltedPlane.Raycast(ray, out float distance))
               {
                   UnityEngine.Vector3 targetPos = ray.GetPoint(distance);
                   UnityEngine.Vector3 worldDir = (targetPos - shot.transform.position).normalized;
                   shot.GetComponent<Shot1Script>().Shoot(worldDir *( 1 + power));
               }*/

    }

    void Test()
    {
        UnityEngine.Vector3 mp = Input.mousePosition;
        mp.z = 60.0f/*0.0f - Camera.main.transform.position.z*/;
        UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(mp);
        Debug.Log($"worldpos test : {worldPos}");
        //UnityEngine.Vector2 mp2D = new UnityEngine.Vector2(mp.x, mp.y);
        GameObject shot = Instantiate(Shot1Prefab, worldPos, UnityEngine.Quaternion.identity);
    }
}

