using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class CoroutineOne : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;
    public bool collected = false;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collected = true;
        //Destroy(gameObject);
    }

    void Update()
    {
        if (collected)
        {
            StartCoroutine(HighJump());
        }

    }

    IEnumerator HighJump()
    {
        Debug.Log("Coroutine one has started...");
        PlayerMove.jumpStrength = 8.0f;
        yield return new WaitForSeconds(10.0f);
        PlayerMove.jumpStrength = 4.0f;
        Debug.Log("Coroutine one has ended...");

    }
}
