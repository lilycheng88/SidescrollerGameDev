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

    [SerializeField]
    public static float jumpStrength = 7.0f;

    [SerializeField]
    float moveSpeed = 4.0f;
    float moveX;

    public float distanceToCheck = 0.5f;
    bool canJump = false;
    bool isGrounded = false;
    bool facingRight = true; 

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        if(collision.gameObject.name == "Floor" || collision.gameObject.name == "Platform" || collision.gameObject.name == "Square" || collision.gameObject.name == "Hinge")
        {
            isGrounded = true;
        }

        if(collision.gameObject.name == "Spike")
        {
            Destroy(gameObject);
            ScoreScript.scoreValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Debug.Log("Flip!");
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


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -49.6f, 10), transform.position.y, transform.position.z);

    }
}
