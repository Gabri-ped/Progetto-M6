using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    private float rotationSpeed = 1f;

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
        Jump();
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        Camera camera = Camera.main;
        Vector3 _camForward = camera.transform.forward;
        Vector3 _camRight = camera.transform.right;
        _camForward.y = 0;
        _camRight.y = 0;
        _camForward.Normalize();
        _camRight.Normalize();
        Vector3 moveDir = (_camForward * direction.z + _camRight * direction.x).normalized;

        float sqrLenght = moveDir.sqrMagnitude;
        if(sqrLenght > 1)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        _rb.MovePosition(transform.position + moveDir * walkSpeed * Time.deltaTime);
        _rb.MoveRotation(transform.rotation);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float _speed = isRunning ? runSpeed : walkSpeed;
        float _animSpeed = direction.magnitude * (isRunning ? 1f : 0.5f);
        _anim.SetFloat("Speed", _animSpeed);
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }
}
