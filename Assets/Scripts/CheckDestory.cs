using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestory : MonoBehaviour
{
    public static int doorDestroy;

    private void Update()
    {
        if (doorDestroy > 4)
        {
            Destroy(gameObject);
        }
    }
}
