using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ShotGenerator : MonoBehaviour
{
    public GameObject   Shot1Prefab;
    [SerializeField] private TrajectoryPred trajectory;
    [SerializeField] private Transform shotSpawnPoint; // Reference to where the shot spawns


    public Image        BarPowerCurrent;
    public Image        BarPowerBase;

    public AudioClip    SECharge;
    public AudioClip[]  SEShoot;
    public AudioClip[]  SEExplosion;
    AudioSource         aud;

    [SerializeField] private float  MAXPOWER = 100.0f;
    [SerializeField] private int    MAXDAMAGE = 10;
    [SerializeField] private float  MAXCHARGETIMER = 2.0f;
    [SerializeField] private float  MINSPEED = 30.0f;
    Vector3 shotSpawnPos;


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
            this.aud.PlayOneShot(this.SECharge);
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
        //    Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //   mouseWorld.z = 60.0f;
         //   Vector3 direction = (mouseWorld - this.shotSpawnPos).normalized;
         //   Vector3 velocity = direction * (MINSPEED + power);

         //   trajectory.ShowTrajectory(this.shotSpawnPos, velocity); //****WIP***


            power += Time.deltaTime * MAXPOWER / MAXCHARGETIMER;
            BarPowerCurrent.fillAmount = Mathf.Clamp01(power / MAXPOWER);
            if (power >= MAXPOWER)
            {
                break;
            }
            yield return null; // wait for next frame
        }

        //バーのリセットと表示
        BarPowerCurrent.fillAmount = 0; //reset bar to 0
        BarPowerCurrent.gameObject.SetActive(false); // hide bars
        BarPowerBase.gameObject.SetActive(false );

        // Find the shot generator
        GameObject shotgen = GameObject.Find("ShotGenerator");

        //弾の位置を計算
        UnityEngine.Vector3 mp = Input.mousePosition;                       //take mouse position
        mp.z = 60.0f - Camera.main.transform.position.z;                    //align mouse position in the Z axis
        UnityEngine.Vector3 worldPos = Camera.main.ScreenToWorldPoint(mp);  //make target's coordinates
        worldPos.z = 60.0f;                                                 //ensure the Z alignment
        this.shotSpawnPos = shotgen.transform.position;      //give initial position to shot

        Vector3 direction = (worldPos - shotgen.transform.position).normalized; //****************************WIP*********************
        Vector3 velocity = direction * (MINSPEED + power);                        //**************************WIP******************

        // Instantiate the shot
        GameObject shot = Instantiate(Shot1Prefab, shotSpawnPos, UnityEngine.Quaternion.identity);
        int damageValue = this.MAXDAMAGE * (int)(power * 1000 / MAXPOWER) / 1000;
        shot.GetComponent<Shot1Script>().SetGenerator(this);
        shot.GetComponent<Shot1Script>().Shoot(velocity, power / 3, damageValue);
        trajectory.Hide(); // This method disables or clears the LineRenderer


        //サウンドエフェクト
        int randomSE = Random.Range(0, SEShoot.Length); // Random index 0 to 2
        aud.PlayOneShot(SEShoot[randomSE]);


        //--------------DEBUG LOGS-------------------------------
        //Debug.Log($"worldPos : {worldPos}");
        //Debug.Log($"bullSpanPos : {shotSpawnPos}");
        //Debug.Log($"distance : {worldPos - shotSpawnPos}");
        //Debug.Log($"distance norm : {(worldPos - shotSpawnPos).normalized}");
    }

    //弾の爆発SE
    public void PlaySEexplosion()
    {
        int randomSE = Random.Range(0, SEExplosion.Length);
    //    Debug.Log($"SE array select : {randomSE}");
        aud.PlayOneShot(SEExplosion[randomSE]);
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

