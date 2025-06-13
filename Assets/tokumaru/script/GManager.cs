using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public enum State
    {
        title,
        Game,
        GameOver,
        Ending
    }

    public State state;
    public State nowState;
    public static GManager Instance = null;
    public static int score = 0;
    public bool sceneCnageOK = false;


    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            state = State.title;
            nowState = State.title;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public State GetSetState
    {
        get { return state; }
        set { state = value;}
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case State.title:

                if (ColectScene())
                {
                    LoadSceneGame();
                }
                break;
            case State.Game:
                if (ColectScene())
                {
                    LoadSceneEndign();
                }

                break;  
            //case State.GameOver:
            //    if (ColectScene())
            //    {

            //    }

            //    break;  
            case State.Ending:
                if (ColectScene())
                {
                    LoadSceneTitle();
                }

                break;  

        }
    }

    void LoadSceneTitle()
    {

    }
    void LoadSceneGame()
    {

    }
    void LoadSceneGameOver()
    {

    }
    void LoadSceneEndign()
    {

    }


    bool ColectScene()
    {
        nowState = state;
        if(nowState != state)
        {
            nowState = state;
            return true;
        }
        return false;
    }

}
