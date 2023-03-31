using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private int doubleJump = 0;

    public bool notDead = true;
    private enum MovementState { idle, running, jumping, falling }
    
    public float playerXAfterFirewall = 34.6f;

    public float playerYAfterFirewall = 4.4f;



    public GameObject teleporter;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (rb.position.y < -20f)
        {
            rb.position = new Vector2(-29.3f, -3.7f);

        }
        dirX = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump")) 
        {
            doubleJump += 1;
            if (IsGrounded())
            {
                doubleJump = 0;
            }
            if (doubleJump < 2)
            {
                rb.velocity = new Vector2(0, jumpForce);
            }
            
        }

        UpdateAnimation();
        }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    
    void OnEnable() {
        if (PlayerPrefs.GetString("survived") == "yes")
        {
            transform.position = new Vector2(playerXAfterFirewall, playerYAfterFirewall);
            Destroy(teleporter);
            PlayerPrefs.SetString("survived", "no");
        }
    }
}
    
