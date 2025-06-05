using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        body.MovePosition(transform.position + MoveSpeed * Time.deltaTime * Vector3.left);
    }
}
