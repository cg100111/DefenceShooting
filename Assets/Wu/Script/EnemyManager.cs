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
    private ObjectPool baseEnemySwordPool;

    private PlayerScript player;

    /// <summary>
    /// 一般敵を派遣する間隔
    /// </summary>
    [SerializeField]
    private float deployBaseDelay;

    /// <summary>
    /// 一般敵を派遣する間隔の範囲
    /// </summary>
    [SerializeField]
    private float deployBaseSwordDelayRange;

    /// <summary>
    /// 一般敵を派遣するカウンター
    /// </summary>
    private float deployBaseCount;

    /// <summary>
    /// 次に一般敵を派遣するタイミング
    /// </summary>
    private float deployBaseTime;

    [SerializeField]
    private DeployInfo baseEnemyDeployInfo;

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
        deployBaseCount = 0.0f;
        deployBaseTime = NextDeployTime();
        baseEnemyPool = GetComponentsInChildren<ObjectPool>().Where(c => c.CompareTag("BaseOP")).First();
        baseEnemySwordPool = GetComponentsInChildren<ObjectPool>().Where(c => c.CompareTag("BaseSwordOP")).First();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        deployBaseCount += Time.fixedDeltaTime;
        if (deployBaseCount >= deployBaseTime)
        {
            deployBaseCount -= deployBaseTime;
            deployBaseTime = NextDeployTime();
            DeployEnemy();
        }
    }

    private float NextDeployTime()
    {
        return Random.Range(deployBaseDelay - deployBaseSwordDelayRange, deployBaseDelay + deployBaseSwordDelayRange);
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
