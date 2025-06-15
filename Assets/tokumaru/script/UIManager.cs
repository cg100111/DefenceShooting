using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //GameObject button;
    //GameObject gameOverText;
    //GameObject BBG;


    public static UIManager uiInstance = null;

    //[SerializeField] private Transform scoreUITransformToEnding;
    //[SerializeField] private GameObject scoreUIPrefabToEnding;
    //GameObject scoreUIToEnding;

    //[SerializeField] private Transform scoreUITransformToGame;
    // [SerializeField] private GameObject scoreUIPrefabToGame;
    //GameObject scoreUIToGame;
    void Awake()
    {
        GManager.instance.GetSetScene = GManager.GameScene.Ending;
        if(uiInstance == null)
        {
            uiInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //public GameObject AppearScoreUIToEnding()
    //{
    //    /*scoreUIToEnding = */
    //    Instantiate(scoreUIPrefabToEnding, scoreUITransformToEnding);
    //    scoreUIToEnding.GetComponent<ScoreText>().SetText("撃破数 " + GManager.instance.GetSetScore.ToString());
    //    return scoreUIToEnding;
    //}


    //シーンにオブジェクトを作成したい場合emptyに
    //recttransformを追加したものを用意しておく
    //public void AppearScoreUIToEnding()
    //{
    //    switch (GManager.instance.nowScene)
    //    {
    //        case GManager.GameScene.Title:
    //            Transform title = GameObject.Find("testobj").transform;
    //            if (title)
    //            {
    //                scoreUIToEnding = Instantiate(scoreUIPrefabToEnding);
    //                scoreUIToEnding.transform.SetParent(title, false);
    //            }
    //            break;
    //        default:
    //            break;
    //    }
    //}


    //public GameObject AppearScoreUIToGame()
    //{
    //    scoreUIToGame = Instantiate(scoreUIPrefabToGame, scoreUITransformToGame);
    //    scoreUIToGame.GetComponent<ScoreText>().SetText("撃破数 " + GManager.instance.GetSetScore.ToString());
    //    return scoreUIToGame;
    //}



    //public void DestroyUIToGame()
    //{
    //    Destroy(scoreUIToGame);
    //}

    //public void DestroyUIToEnding()
    //{
    //    Destroy(scoreUIToEnding);
    //}
    // Start is called before the first frame update
    void Start()
    {

        //button = GameObject.Find("Button");
        //if (button)
        //{
        //    button.SetActive(false);
        //}


        //gameOverText = GameObject.Find("EndingText2");
        //if(gameOverText)
        //{
        //    gameOverText.SetActive(false);
        //}

        //appearCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!gameOverText || !button)
        //{
        //    return;
        //}
    }
}
