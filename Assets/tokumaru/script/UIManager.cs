using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject button;
    GameObject gameOverText;
    GameObject BBG;
    int appearCnt;
    //GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        BBG = GameObject.Find("BBG");
        if (BBG)
        {
            BBG.SetActive(false);
        }

        button = GameObject.Find("Button");
        if (button)
        {
            button.SetActive(false);
        }


        gameOverText = GameObject.Find("EndingText2");
        if(gameOverText)
        {
            gameOverText.SetActive(false);
        }

        appearCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOverText || !button)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            button.SetActive(true);
            gameOverText.SetActive(true);
            BBG.SetActive(true);
        }
    }
}
