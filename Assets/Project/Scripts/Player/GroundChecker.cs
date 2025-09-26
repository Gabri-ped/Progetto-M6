using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private UnityEvent<bool> onIsGroundedChanged;

    public bool IsGrounded { get; private set; }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * _groundCheckDistance);
    }

    void Update()
    {
        bool wasGrounded = IsGrounded;

        IsGrounded = Physics.Raycast(transform.position, -Vector3.up, _groundCheckDistance);

        if (wasGrounded != IsGrounded)
        {
            onIsGroundedChanged.Invoke(IsGrounded);
        }
    }
    
}
