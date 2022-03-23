using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]


public class CoroutineTwo : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;

    public bool collected = false;

    float currScore = BulletNum.scoreValue;

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
            StartCoroutine(BulletShower());
            spriteRenderer.enabled = false;
            capsuleCollider.enabled = false;
            audioSource.Play();
        }

    }

    IEnumerator BulletShower()
    {
        Debug.Log("Coroutine two has started...");
        BulletNum.scoreValue = 30;
        yield return new WaitForSeconds(6.0f);
        PlayerMove.jumpStrength = currScore;
        Debug.Log("Coroutine two has ended...");
        Destroy(gameObject);
    }
}
