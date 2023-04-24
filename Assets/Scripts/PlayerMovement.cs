using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    Animator _anim;
    
    float _dirX = 0f;
    [SerializeField]float _moveSpeed = 7f;
    [SerializeField]float _jumpForce = 7f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_dirX * _moveSpeed, _rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (_dirX > 0f)
        {
            _anim.SetBool("isRunning", true);
            _spriteRenderer.flipX = false;

        }
        else if (_dirX < 0f)
        {
            _anim.SetBool("isRunning", true);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }
    }
}
