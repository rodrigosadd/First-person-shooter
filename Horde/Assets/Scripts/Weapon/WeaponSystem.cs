using System;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private LayerMask _shootingLayer;
    [SerializeField] private WeaponDataSO _currentWeapon;
    [SerializeField] private Transform _camera;

    [Header("Actions")]
    public Action onShootingAction;

    private PlayerInputActions _playerInputActions;
    private float _nextTimeToShoot = 0f;
    private bool _isHolding;

    void Awake()
    {
        _playerInputActions = new PlayerInputActions();        
    }

    void Start()
    {
        _currentWeapon.currentAmmo = _currentWeapon.magazineSize;        
    }

    void Update()
    {
        Shooting();
    }

    void OnEnable()
    {
        _playerInputActions.Enable();
        _playerInputActions.Player.Shooting.performed += ctx => TriggerShooting(true);
        _playerInputActions.Player.Shooting.canceled += ctx => TriggerShooting(false);
    }

    void OnDisable()
    {
        _playerInputActions.Disable();
        _playerInputActions.Player.Shooting.performed -= ctx => TriggerShooting(true);
        _playerInputActions.Player.Shooting.canceled -= ctx => TriggerShooting(false);
    }


    private void Shooting()
    {
        if (_currentWeapon.currentAmmo <= 0 || !_isHolding)
            return;

        if (Time.time >= _nextTimeToShoot)
        {
            _nextTimeToShoot = Time.time + 1f / _currentWeapon.fireRate;

            RaycastHit _hitInfo;

            if (Physics.Raycast(_camera.position, _camera.forward, out _hitInfo, _currentWeapon.maxDistance, _shootingLayer))
            {
                onShootingAction?.Invoke();
                Debug.Log(_hitInfo.transform.name);
            }

            _currentWeapon.currentAmmo--;
        }
    }

    void TriggerShooting(bool value)
    {
        _isHolding = value;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_camera.position, _camera.position + _camera.forward * _currentWeapon.maxDistance);
    }
}
