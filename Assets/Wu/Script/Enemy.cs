using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;
    private EnemyManager manager;
    private Animator animator;

    /// <summary>
    /// 最大体力
    /// </summary>
    [SerializeField]
    private float MAX_HP = 100;

    /// <summary>
    /// 体力
    /// </summary>
    private float HP;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 活動しているか
    /// </summary>
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Inactive();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isActive && HP > 0)
        {
            animator.SetBool("isWalk", true);
            body.MovePosition(transform.position + moveSpeed * Time.deltaTime * Vector3.left);
        }
    }

    public void Initialized()
    {
        HP = MAX_HP;
    }

    public void Active()
    {
        isActive = true;
    }

    public void Inactive()
    {
        isActive = false;
    }

    private void ReduceHP(int damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            HP = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            // get player attack power

        }
    }
}
