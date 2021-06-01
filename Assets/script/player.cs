using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public godPlayerRules god;
    Animator animator;
    public Rigidbody2D rgb;
    public SpriteRenderer renderer;
    
    private float jTime = 0;
    private float rTime = 0;
    public float moveSpeed = 2f;
    public float jumpForce = 3f;
    public int extraJump = 1;

    public bool isGrounded = false;
    public bool isClimbing = false;
    public bool isInjured = false;
    public bool isDashing = false;
    public bool isEnd = false;
    public bool goingRight = false;
    public bool goingLeft = false;
    public bool jumpHigh = false;
    public bool runFast = false;
    public float dashDistance = 15f;
    public float StartDashTimer;
    float DashDirection;
    float CurrentDashTimer;
    public int jumpCount = 0;
    public float jumpCoolDown;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void jHigh()
    {
        jTime += Time.deltaTime;
        if (jTime >= 5) {
            jTime = 0;
            jumpHigh = false;
        }
        jumpForce = 10;
    }
    
    public void rFast()
    {
        rTime += Time.deltaTime;
        if (rTime >= 5) {
            rTime = 0;
            runFast = false;
        }
        moveSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        specialState();
        GodInvertCommands();
        DashCheck();

        if (isInjured) {
            animator.Play("injured_player");
        }
        if (GetComponent<isFreeze>().freeze) {
            animator.Play("Freeze_PLayer");
        } 
        if (!isInjured && !GetComponent<isFreeze>().freeze && !isDashing) {
            isWallRinding();
            Jump();

            if (goingRight) {
                rgb.velocity = new Vector2(moveSpeed, rgb.velocity.y);
                animator.Play("run_player");
                renderer.flipX = false;
            } else if (goingLeft) {
                rgb.velocity = new Vector2(-moveSpeed, rgb.velocity.y);
                animator.Play("run_player");
                renderer.flipX = true;
            } else
                animator.Play("hidle_play");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "ennemy" && !isInjured)
            isInjured = true;
            animator.Play("injured_player");
    }

    void OnBecameInvisible()
    {
        SceneManager.LoadScene("GameOver");
    }

    void specialState()
    {
        if (jumpHigh)
            jHigh();
        if (runFast)
            rFast();
    }

    void Jump() {
        if (isGrounded == true || jumpCount <= extraJump && !GetComponent<isFreeze>().freeze && !isEnd) {
            if (gameObject.layer == 8 && Input.GetButtonDown("Jump")) {
                rgb.velocity = new Vector2(rgb.velocity.x, jumpForce);
                animator.Play("Jump_Player");
                jumpCount++;
            }
            if (gameObject.layer == 9 && Input.GetKey("a")) {
                rgb.velocity = new Vector2(rgb.velocity.x, jumpForce);
                animator.Play("Jump_Player");
                jumpCount++;
            }
        }
    }

    void isWallRinding()
    {
        if (isClimbing) {
            if (Input.GetKeyDown(KeyCode.Space) && renderer.flipX) {
                animator.Play("Jump_Player");
                rgb.velocity = new Vector2(rgb.velocity.x, jumpForce);
                rgb.velocity = new Vector2(moveSpeed, rgb.velocity.y);
            } else if (Input.GetKeyDown(KeyCode.Space) && !renderer.flipX) {
                animator.Play("Jump_Player");
                rgb.velocity = new Vector2(rgb.velocity.x, jumpForce);
                rgb.velocity = new Vector2(-moveSpeed, rgb.velocity.y);
            }
        }
    }

    void GodInvertCommands()
    {
         if (gameObject.layer == 8) {
            if (Input.GetKey("right")){
                goingRight = true;
                goingLeft = false;
            } else if (Input.GetKey("left")){
                goingLeft = true;
                goingRight = false;
            } else {
                goingLeft = false;
                goingRight = false;
            }
            if (god.invert && Input.GetKey("right")) {
                goingRight = false;
                goingLeft = true;
            } else if (god.invert && Input.GetKey("left")) {
                goingRight = true;
                goingLeft = false;
            }
        }
        if (gameObject.layer == 9) {
            if (Input.GetKey("d")){
                goingRight = true;
                goingLeft = false;
            } else if (Input.GetKey("q")){
                goingLeft = true;
                goingRight = false;
            } else {
                goingLeft = false;
                goingRight = false;
            }
            if (god.invert && Input.GetKey("d")) {
                goingRight = false;
                goingLeft = true;
            } else if (god.invert && Input.GetKey("q")) {
                goingRight = true;
                goingLeft = false;
            }
        }
    }

     void DashCheck() {
        if (Input.GetKeyDown(KeyCode.X) && !isDashing && !GetComponent<isFreeze>().freeze && !isEnd) {
            if (gameObject.layer == 8) {
                isDashing = true;
                CurrentDashTimer = StartDashTimer;
                rgb.velocity = Vector2.zero;
                DashDirection = Input.GetAxis("Horizontal");
            }
        }
    }
}