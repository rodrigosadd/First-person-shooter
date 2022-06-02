using UnityEngine;

public class Player : Character, IJumpable
{
    [SerializeField] private CharacterController _characterController;
    private PlayerInputActions _playerInputActions;

    [Header("Gravity")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _gravity;
    public float groundDistanceRadius;

    private float _horizontalMove;
    private float _verticalMove;

    public bool IsGrounded { get; set; }
    public float JumpForce { get; set; }

    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    void Update()
    {
        Movement();        
        Gravity();
    }

    void OnEnable()
    {
        _playerInputActions.Enable();
        _playerInputActions.Player.Jump.performed += ctx => Jump();
    }

    void OnDisable()
    {
        _playerInputActions.Disable();
        _playerInputActions.Player.Jump.performed -= ctx => Jump();        
    }

    public override void Movement()
    {
        _horizontalMove = _playerInputActions.Player.MoveHorizontal.ReadValue<float>();
        _verticalMove = _playerInputActions.Player.MoveVertical.ReadValue<float>();

        move = transform.right * _horizontalMove + transform.forward * _verticalMove;
        _characterController.Move(move * speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            //v = Sqrt h * -2 * g
            velocity.y = Mathf.Sqrt(JumpForce * -2f * _gravity);
        }
    }

    public void Gravity()
    {
        IsGrounded = Physics.CheckSphere(transform.position, groundDistanceRadius, _groundLayer);

        if (IsGrounded && velocity.y < 0f)
            velocity.y = -2f;

        //delta y = 1/2 g * t¹
        velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, groundDistanceRadius);
    }
}
