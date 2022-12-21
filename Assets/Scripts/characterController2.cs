using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    Rigidbody2D _rigid;
    Animator _animator;
    SpriteRenderer _renderer;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float jumpDoubleForce = 1f;
    bool moving = true;
    bool grounded = true;
    bool jump = false;

    bool canDouble = false;

    float moveDirection = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigid.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigid.velocity = new Vector2(speed * moveDirection, _rigid.velocity.y);

        if (jump == true)
        {
            if (canDouble == true)
            {
                _rigid.velocity = new Vector2(_rigid.velocity.x, jumpForce);
            }
            else
            {
                _rigid.velocity = new Vector2(_rigid.velocity.x, jumpDoubleForce);
            }
            jump = false;
        }
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale - 0.1f, 0f, 10f);
            Debug.Log(Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale + 0.1f, 0f, 10f);
            Debug.Log(Time.timeScale);
        }
        */
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1f;
                _renderer.flipX = true;
                _animator.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1f;
                _renderer.flipX = false;
                _animator.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0f;
            _animator.SetFloat("speed", 0);
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;

            if (canDouble)
            {
                grounded = false;
                canDouble = false;
            }
            else
            {
                canDouble = true;
            }
            _animator.SetTrigger("jump");
            _animator.SetBool(name: "grounded", value: false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("grounded", true);
            grounded = true;
            canDouble = false;
        }
    }
}