using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public Image image;
    Color color;
    bool pushButton;

    // Start is called before the first frame update
    void Start()
    {
        color = image.color;
        pushButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pushButton) {
            FlashAndSceneChange(2);
        }
    }

    public void OnButtonClick()
    {
        pushButton = true;
        //SceneManager.LoadScene("Game");
    }
    void FlashAndSceneChange(int time_)
    {

        if(time_ >= 0)
        {
            if ((time_ / 4) % 2 == 1)
            {
                color.a = 1.0f;
                image.color = color;
            }
            else
            {
                color.a = 0.0f;
                image.color = color;
            }
        }
        else
        {
            return;
        }


    }
}
