using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{

    //�O������g����
    //�Q�Ƃ����܂��Ă�
    //GManager.instance.�C�ӂ̊֐��E�ϐ�
    //GManager.GameScene.GameScene�̔C�ӂ̃V�[��
    //GManager.GameScene.GetSetScene�� �擾�E����ւ��\GetSetScene�̕�����ς���ƕʂ̕ϐ����擾����ւ��\�@���̂Ƃ���scene��score�̂�
    //GManager.GameScene.SceneChange()�@�V�[���̃��[�h����Ń��[�h�����
    //GManager����o�����̂�����΂���̏������������s��
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
