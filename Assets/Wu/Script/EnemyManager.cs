using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /// <summary>
    /// ��������ꏊ
    /// </summary>
    public Transform[] SpawnPositions;
    /// <summary>
    /// �G�l�~�[�T���v��
    /// </summary>
    public GameObject EnemyPrefab;
    /// <summary>
    /// �����̊Ԋu
    /// </summary>
    [SerializeField]
    private float SpawnDelay;
    /// <summary>
    /// �����Ԋu�͈̔�
    /// </summary>
    [SerializeField]
    private float SpawnDelayRange;
    /// <summary>
    /// �����J�E���^�[
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
