using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private AudioSource audioSource;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.Play();
        if(other.CompareTag("Player")) {
            gm.lastCheckPointPos = transform.position;
            audioSource.volume = 0.0f;
        }
    }
}
