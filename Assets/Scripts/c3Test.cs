using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class c3Test : MonoBehaviour
{
    public float speed = 1.0f;
    public float jump = 0.0f;
    Rigidbody2D r2d;
    Animator _animator;
    Vector3 charPos;
    [SerializeField] GameObject _camera;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();  //caching r2d
        _animator = GetComponent<Animator>();   //caching anim
        charPos = transform.position;
    }
    private void FixedUpdate() //50 fps
    {
        //r2d.velocity = new Vector2(speed, jump);
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z = -.5f);
    }
    void Update()
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos;
        //_animator.SetFloat("speed",speed);
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z = -.5f);
    }
}