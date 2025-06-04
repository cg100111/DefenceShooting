using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /// <summary>
    /// 生成する場所
    /// </summary>
    public Transform[] SpawnPositions;
    /// <summary>
    /// エネミーサンプル
    /// </summary>
    public GameObject EnemyPrefab;
    /// <summary>
    /// 生成の間隔
    /// </summary>
    [SerializeField]
    private float SpawnDelay;
    /// <summary>
    /// 生成間隔の範囲
    /// </summary>
    [SerializeField]
    private float SpawnDelayRange;
    /// <summary>
    /// 生成カウンター
    /// </summary>
    private float SpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
