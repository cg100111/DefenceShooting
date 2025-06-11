using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public Image image;
    public Animator animator;
    Color color;
    bool pushButton;
    float timer;
    float limit;
    public bool sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        color = image.color;
        animator = gameObject.GetComponent<Animator>();
        pushButton = false;
        timer = 0.0f;
        limit = 30.0f;
        sceneChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushButton)
        {
            if (timer >= limit)
            {
                animator.SetBool("OnPush", false);
                pushButton = false;
                sceneChange = true;
                Debug.Log("animator,PushButton false");
            }
            timer += 1.0f;
        }
    }

    public void OnButtonClick()
    {
        pushButton = true;
        animator.SetBool("OnPush", true);
        Debug.Log("animator,PushButton true");
    }
}
