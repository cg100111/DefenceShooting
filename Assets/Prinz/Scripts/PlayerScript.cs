using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : Character
{
    public Image BarHPCurrent;
    public float HP = 100.0f;
    private const float MAXHP = 100.0f;
    [SerializeField] private float timerEndingTransition = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //   testTime -= Time.deltaTime;
        //   HP = testTime;
        BarHPCurrent.fillAmount = Mathf.Clamp01(HP / MAXHP);
    }

    private void ReduceHP(float amount)
    {
        HP = Mathf.Min(0, amount);
        if(HP <= 0)
        {
            StartCoroutine(EndingSceneTransition()); //エンディングシーンの切り替え
        }    
    }

    IEnumerator EndingSceneTransition()
    {
        while (timerEndingTransition > 0)
        {
            timerEndingTransition -= Time.deltaTime;
            if(timerEndingTransition <= 0)
            {
                break;
            }
            yield return null; // wait for next frame
        }
        SceneManager.LoadScene("EndingScene"); //タイマーが終わったら、エンディングに切り替える
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float damage = collision.gameObject.GetComponent<Enemy>().GetAttackPower();
            if (collision.gameObject.GetComponent<Enemy>().isAttack)
            {
                ReduceHP(damage);
            }
        }
    }
}
