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
        BarHPCurrent.fillAmount = Mathf.Clamp01(this.HP / MAXHP);
    }

    private void ReduceHP(float amount)
    {
        this.HP = Mathf.Max(0, this.HP - amount);
        if(this.HP <= 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyAttackCollider"))
        {
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            if(enemy != null)
            {
                float damage = enemy.GetAttackPower();
                ReduceHP(damage);
                Debug.Log($"Damage : {damage}");
                Debug.Log($"player hp : {this.HP}");
            }
            else
            {
                Debug.LogWarning("Enemy component not found in parent!");
            }
        }
    }
}
