using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public Animator animator;

    public static float jumpStrength = 8.0f;

    private AudioSource audioSource;
    public AudioClip death;
    

    [SerializeField]
    public static float moveSpeed = 4.0f;
    public static float moveX;

    public float distanceToCheck = 0.5f;
    bool canJump = false;
    bool isGrounded = false;
    public static bool facingRight = true; 

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            canJump = true;
        }
    }

    void Jump()
    {
        if (!isGrounded)
            return;

        isGrounded = false;

        rigidBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag("Spike"))
        {

            Destroy(gameObject);
            BulletNum.scoreValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Flip();
            facingRight = true;
            MoveOnTrigger4.canStartMoving = false;
        }

        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            BulletNum.scoreValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Flip();
            facingRight = true;
            MoveOnTrigger4.canStartMoving = false;
            
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            BulletNum.scoreValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Flip();
            facingRight = true;
            MoveOnTrigger4.canStartMoving = false;

        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveX * moveSpeed, rigidBody.velocity.y);

        if (canJump == true)
        {
            canJump = false;
            Jump();
        }

        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }

    }

    private void Update()
    {
        PlayerControls();
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        animator.SetBool("OffGround", !isGrounded);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -100.0f, 10), transform.position.y, transform.position.z);

    }
}
