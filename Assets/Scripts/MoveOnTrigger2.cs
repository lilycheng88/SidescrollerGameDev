using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger2 : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 2.0f;

    public bool moveUp;
    public bool moveDown;

    public static bool canStartMoving;

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
        if (canStartMoving)
        {
            if (moveDown)
            {
                Debug.Log("Moving Down");
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }

            if (moveUp)
            {
                Debug.Log("Moving Up");
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }

            if (transform.position.y <= pointB.position.y)
            {
                moveUp = true;
                moveDown = false;
            }
            if (transform.position.y >= pointA.position.y)
            {
                moveDown = true;
                moveUp = false;
            }
        }
    }
}
