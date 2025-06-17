using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{

    //外側から使える
    //参照が絡まってる
    //GManager.instance.任意の関数・変数
    //GManager.GameScene.GameSceneの任意のシーン
    //GManager.GameScene.GetSetSceneで 取得・入れ替え可能GetSetSceneの部分を変えると別の変数も取得入れ替え可能　今のところsceneとscoreのみ
    //GManager.GameScene.SceneChange()　シーンのロードこれでロードすると
    //GManagerから出すものがあればそれの初期化処理を行う
    public enum GameScene
    {
        Title,
        Game,
        GameOver,
        Ending
    }

    public bool sceneChange;

    private GameScene scene;
    public GameScene nowScene;
    public static GManager instance = null;
    public static int score = 0;
    //public bool sceneCnageOK = true;


    private void Awake()
    {
        if (!instance)
        {
            Debug.Log("awake");
            DontDestroyOnLoad(gameObject);
            instance = this;
            scene = GameScene.Ending;
            nowScene = GameScene.Ending;
            sceneChange = true;
}
        else
        {
            Destroy(this.gameObject);
        }
    }

    //public static GManager GetSetInstance
    //{
    //    get { return instance; }
    //    private set { }
    //}

    public GameScene GetSetScene
    {
        get { return nowScene; }
        set { nowScene = value;}
    }

    public int GetSetScore
    {
        get { return score; }
        set { score += value; }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sceneChange)
        {
            switch (nowScene)
            {
                case GameScene.Title:
                    LoadSceneTitle();
                    break;
                case GameScene.Game:
                    LoadSceneGame();
                    break; 
                case GameScene.Ending:
                    LoadSceneEnding();
                    break;
                default:
                    break;
            }
        }
    }

    void LoadSceneTitle()
    {
        if (sceneChange)
        {
            sceneChange = false;
        }
        else
        {
            return;
        }
    }
    void LoadSceneGame()
    {
        if (sceneChange)
        {

            //UIManager.uiInstance.AppearScoreUIToGame();
            sceneChange = false;
        }
        else
        {
            return;
        }
    }
    void LoadSceneGameOver()
    {
        if (sceneChange)
        {
            sceneChange = false;
        }
        else
        {
            return;
        }
    }

    void LoadSceneEnding()
    {
        if (sceneChange)
        {
            //UIManager.uiInstance.AppearScoreUIToEnding();
            sceneChange = false;
        }
        else
        {
            return;
        }
    }


    bool ColectScene()
    {
        if(nowScene != scene)
        {
            scene = nowScene;
            return true;
        }
        return false;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SetScore(int score_)
    {
        score = score_;
    }

    public void SceneChange()
    {
        switch (nowScene)
        {
            case GameScene.Title:
                nowScene = GameScene.Game;
                //SceneManager.LoadScene("Game");
                break;
            case GameScene.Game:
                nowScene = GameScene.Ending;
                //UIManager.uiInstance.DestroyUIToGame();
                //SceneManager.LoadScene("Ending");
                break;
            case GameScene.Ending:
                Debug.Log("non");
                nowScene = GameScene.Title;
                //UIManager.uiInstance.DestroyUIToEnding();
                ResetScore();
                SceneManager.LoadScene("Title");
                break;
            default:
                break;
        }
        sceneChange = true;
    }

}
