using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private AudioSource audioSource;
    public bool hasChecked;

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
            hasChecked = true;
        }
    }

    private void Update()
    {
        if(hasChecked)
        {
            StartCoroutine(HighSpeed());
        }
        else
        {
            audioSource.volume = 1.0f;
        }
    }

    IEnumerator HighSpeed()
    {
        Debug.Log("Coroutine one has started...");
        yield return new WaitForSeconds(1.0f);
        audioSource.volume = 0.0f;
        Debug.Log("Coroutine one has ended...");
        
    }
}
