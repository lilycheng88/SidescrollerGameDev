using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ButtonTrigger5 : MonoBehaviour
{
    public Animator animator;
    public bool pressed;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveOnTrigger4.canStartMoving = true;

        Debug.Log("Can Start Moving");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit Trigger.");
    }

    private void Update()
    {
        animator.SetBool("IsPressed", MoveOnTrigger4.canStartMoving);
    }
}
