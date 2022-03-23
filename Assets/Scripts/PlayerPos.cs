using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = new Vector3(gm.lastCheckPointPos.x, gm.lastCheckPointPos.y, gameObject.transform.position.z);
    }

}
