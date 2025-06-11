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
    public Image BarPowerCurrent;
    public Image BarPowerBase;
    public AudioClip SECharge;
    public AudioClip[] SEShoot;

    AudioSource aud;
    private const float MAXPOWER = 100.0f;
    private const float MINSPEED = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.aud.PlayOneShot(this.SECharge); //broken
            Debug.Log("Mouse click");


            StartCoroutine(ChargeAndFire());
        //    Test();  //debug
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            this.aud.Stop();

        }
    }

    IEnumerator ChargeAndFire()
    {
        float power = 0.0f;
        BarPowerCurrent.gameObject.SetActive(true); // show bars
        BarPowerBase.gameObject.SetActive(true);

        if(Input.GetMouseButtonDown(1))  //debug
        {


        }

        while (Input.GetMouseButton(0))
        {
            power += Time.deltaTime * 33;
            BarPowerCurrent.fillAmount = Mathf.Clamp01(power / MAXPOWER);
            if (power >= MAXPOWER)
            {
                break;
            }
            yield return null; // wait for next frame
        }

        //this.aud.Stop();

        BarPowerCurrent.fillAmount = 0; //reset bar to 0
        BarPowerCurrent.gameObject.SetActive(false); // hide bars
        BarPowerBase.gameObject.SetActive(false );

        // Find the shot generator
        GameObject shotgen = GameObject.Find("ShotGenerator");

        UnityEngine.Vector3 mp = Input.mousePosition;                       //take mouse position
        mp.z = 60.0f - Camera.main.transform.position.z;                    //align mouse position in the Z axis
        UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(mp);  //make target's coordinates
        worldPos.z = 60.0f;                                                 //ensure the Z alignment
        UnityEngine.Vector3 shotSpawnPos = shotgen.transform.position;      //give initial position to shot

        // Instantiate the shot
        GameObject shot = Instantiate(Shot1Prefab, shotSpawnPos, UnityEngine.Quaternion.identity);
        shot.GetComponent<Shot1Script>().Shoot((worldPos - shotSpawnPos).normalized * (MINSPEED + power), power / 3);

        int randomSE = Random.Range(0, SEShoot.Length); // Random index 0 to 2
        aud.PlayOneShot(SEShoot[randomSE]);
        //--------------DEBUG LOGS-------------------------------
        //Debug.Log($"worldPos : {worldPos}");
        //Debug.Log($"bullSpanPos : {shotSpawnPos}");
        //Debug.Log($"distance : {worldPos - shotSpawnPos}");
        //Debug.Log($"distance norm : {(worldPos - shotSpawnPos).normalized}");
    }

    //*******************************   DEBUG   **********************************
    void Test()
    {
        UnityEngine.Vector3 mp = Input.mousePosition;
        mp.z = 60.0f/*0.0f - Camera.main.transform.position.z*/;
        UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(mp);
        //UnityEngine.Vector2 mp2D = new UnityEngine.Vector2(mp.x, mp.y);
        GameObject shot = Instantiate(Shot1Prefab, worldPos, UnityEngine.Quaternion.identity);


        //Debug.Log($"worldpos test : {worldPos}");
    }
    //****************************************************************************
}

