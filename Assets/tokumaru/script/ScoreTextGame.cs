using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextGame : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "åÇîjêî " + GManager.instance.GetSetScore.ToString() + "ëÃ";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "åÇîjêî " + GManager.instance.GetSetScore.ToString() + "ëÃ";
    }
}
