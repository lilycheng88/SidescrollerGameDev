using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class BulletCollect : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

    bool collected = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collected = true;
        }
    }

    void Update()
    {
        if(collected)
        {
            BulletNum.scoreValue++;
            Destroy(gameObject);
        }

    }


}
