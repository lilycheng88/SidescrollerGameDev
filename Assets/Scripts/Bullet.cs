using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Enemy")
        {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }

        if(hitInfo.name == "Door Destroy")
        {
            CheckDestory.doorDestroy++;
            Destroy(gameObject);

        }
    }

    private void Flip()
    {
        PlayerMove.facingRight = !PlayerMove.facingRight;
        Debug.Log("Flip!");
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        if (PlayerMove.moveX > 0 && !PlayerMove.facingRight)
        {
            Flip();
        }
        else if (PlayerMove.moveX < 0 && PlayerMove.facingRight)
        {
            Flip();
        }
    }

}
