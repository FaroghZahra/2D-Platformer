using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    private BoxCollider2D _coll;
    private Animator _anim;
    private float _dirX;
    private SpriteRenderer _flip;

    [SerializeField] private LayerMask _jumpableGround;
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _jumpSpeed = 7f;
    
    private enum playerState
    {
        idle,
        running,
        jumping,
        falling
    }

    [SerializeField] private AudioSource _jumpSound;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _flip = GetComponent<SpriteRenderer>();
        _coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_dirX * _moveSpeed, _rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _jumpSound.Play();
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpSpeed);
        }
        SwitchAnimations();
        
        
    }

    private void SwitchAnimations()
    {
        playerState currState;
        //check for idle and running 
        if (_dirX > 0f)
        {
            currState = playerState.running;
            _flip.flipX = false;
        }
        else if(_dirX < 0f)

        {
            currState = playerState.running;
            _flip.flipX = true;
        }
        else
        {
            currState = playerState.idle;
        }
        
        //check for jumping and falling
        if (_rb.velocity.y > .1f)
        {
            currState = playerState.jumping;
        }
        else if (_rb.velocity.y < -0.1f)
        {
            currState = playerState.falling;
        }
        _anim.SetInteger("PlayerState", (int)currState);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_coll.bounds.center, _coll.bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
    }
}
