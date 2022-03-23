using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 3.0f;

    public bool moveRight;
    public bool moveLeft;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }

    private void FixedUpdate()
    {
            speed = 3.0f;
            if (moveRight)
            {
                Debug.Log("Moving Right");
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }

            if (moveLeft)
            {
                Debug.Log("Moving Left");
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }

            if (transform.position.x >= pointB.position.x)
            {
                moveRight = false;
                moveLeft = true;
            }
            if (transform.position.x <= pointA.position.x)
            {
                moveLeft = false;
                moveRight = true;
            }
   
    }
}
