using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    BoxCollider2D _boxCollider2D;
    SpriteRenderer _spriteRenderer;
    Animator _anim;

    [SerializeField] LayerMask _jumpableGround;
    
    float _dirX = 0f;
    [SerializeField]float _moveSpeed = 7f;
    [SerializeField]float _jumpForce = 7f;
    
    enum _MovementState { idle, running, jumping, falling}
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_dirX * _moveSpeed, _rb.velocity.y);

        if (Input.GetButtonDown("Jump") && _isGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        _MovementState state;
        if (_dirX > 0f)
        {
            state = _MovementState.running;
            _spriteRenderer.flipX = false;

        }
        else if (_dirX < 0f)
        {
            state = _MovementState.running;
            _spriteRenderer.flipX = true;
        }
        else
        {
            state = _MovementState.idle;
        }

        if (_rb.velocity.y > .1f)
        {
            state = _MovementState.jumping;
        }
        else if (_rb.velocity.y < -.1f)
        {
            state = _MovementState.falling;
        }
        
        _anim.SetInteger("state", (int)state);
    }

    bool _isGrounded()
    {
        return Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
    }
}
