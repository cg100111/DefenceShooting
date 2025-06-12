using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

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

    /// <summary>
    /// 開始位置(上)
    /// </summary>
    [SerializeField]
    private Vector3 startTopPos;

    /// <summary>
    /// 開始位置(下)
    /// </summary>
    [SerializeField]
    private Vector3 startBottomPos;

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
            DeployEnemy();
        }
    }

    private float NextDeployTime()
    {
        return Random.Range(spawnDelay - spawnDelayRange, spawnDelay + spawnDelayRange);
    }

    private void DeployEnemy()
    {
        // 表示するlayerはintですから、敵のY座標もintにする、そうしないと変になる
        float startPosY = GetStartPos();
        Vector3 startPos = new(startTopPos.x, (int)startPosY, startTopPos.z);

        Enemy enemy = baseEnemyPool.Borrow();
        if (enemy)
        {
            enemy.transform.position = startPos;
            enemy.SetManager(this);
            enemy.GetComponent<SortingGroup>().sortingOrder = Mathf.Abs((int)(startPosY - startTopPos.y));
            enemy.Active();
        }
    }

    private float GetStartPos()
    {
        return Random.Range(startTopPos.y, startBottomPos.y);
    }

    public void RecycleEnemy(Enemy enemy)
    {
        baseEnemyPool.Recycle(enemy);
    }

    public void RecycleAllEnemy()
    {
        baseEnemyPool.RecycleAllEnemy();
    }
}
