using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    /// <summary>
    /// �G�l�~�[�T���v��
    /// </summary>
    public GameObject EnemyPrefab;

    /// <summary>
    /// �����ɏo������G�̍ő吔
    /// </summary>
    [SerializeField]
    private int MAX_ENEMY;

    [SerializeField]
    private Vector3 InitPos;
    private List<Enemy> UnUse;
    private List<Enemy> Used;
    // Start is called before the first frame update
    void Start()
    {
        UnUse = new List<Enemy>();
        Used = new List<Enemy>();
        PrepareEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PrepareEnemies()
    {
        for(int index = 0; index < MAX_ENEMY; index++)
        {
            CreateEnemy();
        }
    }

    private Enemy CreateEnemy()
    {
        GameObject.Instantiate(EnemyPrefab, );
        return new Enemy();
    }
}
