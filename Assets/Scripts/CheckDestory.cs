using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestory : MonoBehaviour
{
    public bool collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }

    private void Update()
    {

        if (collided && ScoreScript.scoreValue == 12)
        {
            Destroy(gameObject);
        }
    }
}
