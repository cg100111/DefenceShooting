using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Image BarHPCurrent;
    public float HP = 100.0f;
    public const float MAXHP = 100.0f;
    float testTime = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        testTime -= Time.deltaTime;
        HP = testTime;
        BarHPCurrent.fillAmount = Mathf.Clamp01(HP / MAXHP);
    }
}
