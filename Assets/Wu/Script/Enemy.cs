using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Rigidbody2D body;
    private EnemyManager manager;
    private Animator animator;
    private CircleCollider2D attackCollider;

    private StateManager stateManager;

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
    public bool isActive {  get; private set; }

    /// <summary>
    /// 攻撃してるか
    /// </summary>
    public bool isAttack { get; private set; }

    /// <summary>
    /// 攻撃されてるか
    /// </summary>
    public bool isHit { get; private set; }

    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        attackCollider = gameObject.GetComponentInChildren<CircleCollider2D>();
        stateManager = new StateManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Active();
        }
        
    }

    public Animator GetAnimator() { return animator; }

    public void Move()
    {
        body.MovePosition(transform.position + moveSpeed * Time.deltaTime * Vector3.left);
    }

    public void Initialized()
    {
        HP = MAX_HP;
        stateManager.ChangeState(new EnemyIdleState(this, stateManager));
    }

    public void Active()
    {
        isActive = true;
    }

    public void Inactive()
    {
        isActive = false;
    }

    public void SetManager(EnemyManager manager)
    {
        this.manager = manager;
    }

    private void ReduceHP(int damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            HP = 0;
            animator.SetTrigger("death");
        }
        else
        {
            StartHit();
        }
    }

    public bool IsAlive()
    {
        return HP > 0;
    }

    public void OpenAttackCollider()
    {
        if (attackCollider)
            attackCollider.enabled = true;
    }

    public void CloseAttackCollider()
    {
        if (attackCollider)
            attackCollider.enabled = false;
    }

    private void StartAttack()
    {
        isAttack = true;
        animator.SetBool("attack", isAttack);
    }

    public void AttackFinished()
    {
        isAttack = false;
        animator.SetBool("attack", isAttack);
    }

    private void StartHit()
    {
        isHit = true;
        animator.SetBool("isHit", isHit);
    }

    public void HitFinished()
    {
        isHit = false;
        animator.SetBool("isHit", isHit);
    }

    public void DeathFinished()
    {
        manager.RecycleEnemy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 攻撃された
        if(!isHit && collision.gameObject.CompareTag("PlayerBullet"))
        {
            // get Bullet attack power
            //float damage = collision.gameObject.GetComponent<>();

            ReduceHP(10);

        }
    }
}
