using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;

    [Header("Gravity Variables")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _gravity;
    [SerializeField] private float _groundDistanceRadius;

    [Header("Jump Variables")]
    [SerializeField] private float _jumpForce;


    private Vector3 _move;
    private Vector3 _velocity;
    private float _horizontalMove;
    private float _verticalMove;
    private bool _isGrounded;

    void Update()
    {
        Movement();
        Jump();
        Gravity();
    }

    public void Movement()
    {       
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");

        _move = transform.right * _horizontalMove + transform.forward * _verticalMove;
        _characterController.Move(_move * _speed * Time.deltaTime);        
    }

    public void Gravity()
    {
        _isGrounded = Physics.CheckSphere(transform.position, _groundDistanceRadius, _groundLayer);

        if (_isGrounded && _velocity.y < 0f)
            _velocity.y = -2f;

        //v = v * g * t
        //delta y = 1/2 g * t¹
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            //v = Sqrt h * -2 * g
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _groundDistanceRadius);
    }
}
