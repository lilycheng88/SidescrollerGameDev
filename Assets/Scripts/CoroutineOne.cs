using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]


public class CoroutineOne : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;

    public bool collected = false;

    private AudioSource audioSource;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collected = true;
    }

    void Update()
    {
        if (collected)
        {
            StartCoroutine(HighJump());
            spriteRenderer.enabled = false;
            capsuleCollider.enabled = false;
            audioSource.Play();
        }

    }

    IEnumerator HighJump()
    {
        Debug.Log("Coroutine one has started...");
        PlayerMove.jumpStrength = 12.0f;
        yield return new WaitForSeconds(6.0f);
        PlayerMove.jumpStrength = 7.0f;
        Debug.Log("Coroutine one has ended...");
        Destroy(gameObject);
    }
}
