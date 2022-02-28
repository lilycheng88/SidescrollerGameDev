using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ButtonTrigger : MonoBehaviour
{

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
        spriteRenderer.color = new Color(1.0f, 0.5f, 0.25f, 0.5f); //red, blue, green, alpha

        MoveOnTrigger.canStartMoving = true;

        Debug.Log("Can Start Moving");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit Trigger.");
    }
}
