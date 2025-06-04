using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour
{
    public Image image;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = image.color;
        color.a = 0.0f;
        image.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a < 1.0f)
        {
            Debug.Log("non");
            color.a += 0.001f;
            image.color = color;
        }
    }
}
