using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Rigidbody2D body;
    private EnemyManager manager;
    private Animator animator;
    private CircleCollider2D attackCollider;
    private PlayerScript target;
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
    /// 攻撃力
    /// </summary>
    private float attackPower;

    /// <summary>
    /// 活動しているか
    /// </summary>
    public bool isActive { get; private set; }

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
        stateManager.Update(target);
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public Rigidbody2D GetBody()
    {
        return body;
    }

    public void Move()
    {
        body.MovePosition(transform.position + moveSpeed * Time.deltaTime * Vector3.left);
    }

    public void Initialized()
    {
        HP = MAX_HP;
        CloseAttackCollider();
        isAttack = false;
        isHit = false;
        Inactive();
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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

    public void SetTarget(PlayerScript target)
    {
        this.target = target;
    }

    private void ReduceHP(int damage)
    {
        HP -= damage;
        if (HP <= 0.0f)
        {
            HP = 0;
            stateManager.ChangeState(new EnemyDeathState(this, stateManager));
        }
        else
        {
            isHit = true;
            stateManager.ChangeState(new EnemyHurtState(this, stateManager));
        }
    }

    public float GetAttackPower()
    {
        return attackPower;
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

    public void AttackFinished()
    {
        isAttack = false;
        stateManager.ChangeState(new EnemyWalkState(this, stateManager));
    }

    public void HitFinished()
    {
        isHit = false;
    }

    public void DeathFinished()
    {
        manager.RecycleEnemy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 攻撃された
        if (!isHit && collision.gameObject.CompareTag("PlayerBullet"))
        {
            // get Bullet attack power
            int damage = collision.gameObject.GetComponent<Shot1Script>().GetDamageValue();
            ReduceHP(damage);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // 攻撃する
        if (!isHit && !isAttack && collision.gameObject.CompareTag("Player"))
        {
            isAttack = true;
        }
    }
}
