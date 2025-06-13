using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreateBO : MonoBehaviour
{
    public Image image;
    Color color;
    PushButton pushButton;
    GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        color = image.color;
        color.a = 0.0f;
        image.color = color;
        button = GameObject.Find("Button");
        if(button != null)
        {
            pushButton = button.GetComponent<PushButton>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pushButton)
        {
            return;
        }

        if (pushButton.sceneChange)
        {
            color.a += 0.002f;
            image.color = color;
            if (color.a >= 1.0f)
            {
                pushButton.sceneChange = false;
                SceneManager.LoadScene("Title");

            }
        }
    }
}
