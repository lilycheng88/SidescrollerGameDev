using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    public Quaternion myRotation;
    public GameObject followObject;

    private void Start()
    {
        myRotation = gameObject.transform.rotation;

    }

void Update()
    {
        followObject = GameObject.Find("Player");

        if (followObject.transform.position.y > 1)
        {
            transform.position = new Vector3(Mathf.Clamp(followObject.transform.position.x, -49.6f, 0), Mathf.Clamp(followObject.transform.position.y, followObject.transform.position.y, 100), transform.position.z);
            Debug.Log("Higher Up");
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(followObject.transform.position.x, -49.6f, 0), Mathf.Clamp(followObject.transform.position.y, 0, 0), transform.position.z);
            Debug.Log("On Ground");
        }

        this.transform.rotation = myRotation;

    }
}
