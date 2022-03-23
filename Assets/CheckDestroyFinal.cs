using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckDestoryFinal : MonoBehaviour
{
    public Animator animator;
    public static int doorDestroy;
    public bool collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collided = true;
        }
        else
        {
            collided = false;
        }
    }

    private void Update()
    {
        animator.SetInteger("FireDamage", doorDestroy);

        if (doorDestroy > 3 && collided)
        {
            SceneManager.LoadScene("Win");
        }
    }
}