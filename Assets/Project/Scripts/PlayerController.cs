using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float walkSpeed = 5f;
    private float runSpeed = 8f;
    
    private Animator _anim;
    private Rigidbody _rb;
    float h;
    float v;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float _speed = isRunning ? runSpeed : walkSpeed;
        float _animSpeed = direction.magnitude * (isRunning ? 1f : 0.5f);
        _anim.SetFloat("Speed", _animSpeed);
        _rb.MovePosition(_rb.position + direction * _speed * Time.deltaTime);
        _rb.MoveRotation(Quaternion.LookRotation(direction == Vector3.zero ? transform.forward : direction));

    }
}
