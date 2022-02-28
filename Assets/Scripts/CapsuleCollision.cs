using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCollision : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider2D;

    bool collected = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collected = true;
    }

    void Update()
    {
        if (collected)
        {
            Destroy(gameObject);
        }

    }
}
