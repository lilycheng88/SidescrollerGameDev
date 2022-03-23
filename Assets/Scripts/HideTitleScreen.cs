using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTitleScreen : MonoBehaviour
{
    void Update()
    {
    
       StartCoroutine(HideTitle());
       
    }

    IEnumerator HideTitle()
    {
        Debug.Log("Coroutine one has started...");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Coroutine one has ended...");
        Destroy(gameObject);
    }
}
