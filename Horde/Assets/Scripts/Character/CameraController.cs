using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _sensitivityMultiplier;
    [SerializeField] private bool _reverseMovement;

    private float _xMovement;
    private float _yMovement;
    private float _camRotation = 0f;


    void Start()
    {
        SetCursorLockState(CursorLockMode.Locked);
        SetCursorVisibility(false);
    }

    void Update()
    {
        Movement();        
    }

    public void Movement()
    {
        _xMovement = Input.GetAxis("Mouse X") * (_sensitivity * _sensitivityMultiplier) * Time.deltaTime;
        _yMovement = Input.GetAxis("Mouse Y") * (_sensitivity * _sensitivityMultiplier) * Time.deltaTime;

        if(!_reverseMovement)
            _camRotation -= _yMovement;
        else
            _camRotation += _yMovement;

        _camRotation = Mathf.Clamp(_camRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * _xMovement); 
    }

    public void SetCursorLockState(CursorLockMode mode)
    {
        Cursor.lockState = mode;
    }

    public void SetCursorVisibility(bool value)
    {
        Cursor.visible = value;
    }
}
