using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform checkPosition;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D _rb;
    private Animator _anim;
    private AudioSource _audio;
    private float _moveDirection;
    private bool _isFacingRight = true;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal");
        _anim.SetBool("isRunning", _moveDirection != 0);

        CheckFallingState();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_moveDirection * moveSpeed, _rb.velocity.y);

        if (_moveDirection > 0 && !_isFacingRight)
            Flip();
        else if (_moveDirection < 0 && _isFacingRight)
            Flip();
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _anim.SetTrigger("Jump");
            _audio.Play();
        }
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(checkPosition.position, checkRadius, whatIsGround);
        _anim.SetBool("isGrounded", _isGrounded);
    }
    private void CheckFallingState()
    {
        if (!_isGrounded)
        {
            _anim.SetBool("isFalling", _rb.velocity.y < 0f);
        }
    }
}
