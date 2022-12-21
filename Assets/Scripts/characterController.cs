using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1f; 
    Rigidbody2D _rigid;
    Animator _animator;
    Vector3 charPos;
    [SerializeField] new Camera _camera;
    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();  // caching Rigidbody2D
        _animator = GetComponent<Animator>();   // caching Animator
        charPos = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0f);
        }

        else
        {
            _animator.SetFloat("speed", speed);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)       
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)    
        {
            _spriteRenderer.flipX = true;
        }
        transform.position = charPos;

    }


    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1);
    }
}
