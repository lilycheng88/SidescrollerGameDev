using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class CoinDestroy : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

    bool collected = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collected = true;
    }

    void Update()
    {
        if(collected)
        {
            ScoreScript.scoreValue++;
            Destroy(gameObject);
        }

    }


}
