using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum EnemyType
{
    BaseEnemy,
    AttackEnemy
}

public class EnemyManager : MonoBehaviour
{
    private ObjectPool baseEnemyPool;

    /// <summary>
    /// 派遣の間隔
    /// </summary>
    [SerializeField]
    private float spawnDelay;

    /// <summary>
    /// 派遣間隔の範囲
    /// </summary>
    [SerializeField]
    private float spawnDelayRange;

    /// <summary>
    /// 派遣カウンター
    /// </summary>
    private float deployCount;

    private float deployTime;


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        deployCount = 0.0f;
        deployTime = NextDeployTime();
        baseEnemyPool = GetComponentsInChildren<ObjectPool>().Where(c => c.CompareTag("BaseOP")).First();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        deployCount += Time.fixedDeltaTime;
        if(deployCount >= deployTime)
        {
            deployCount -= deployTime;
            deployTime = NextDeployTime();
            GetEnemy();
        }
    }

    private float NextDeployTime()
    {
        return Random.Range(spawnDelay - spawnDelayRange, spawnDelay + spawnDelayRange);
    }

    private void GetEnemy()
    {

    }

    public void RecycleAllEnemy()
    {
       
    }
}
