using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    private Quaternion myRotation;

    private void Start()
    {
        myRotation = this.transform.rotation;

}

void Update()
    {
        var followObject = GameObject.Find("Player");

        if (followObject.transform.position.y > 1)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 100), Mathf.Clamp(transform.position.y, followObject.transform.position.y, 100), transform.position.z);
            Debug.Log("Higher Up");
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 100), Mathf.Clamp(transform.position.y, -2, 0), transform.position.z);
            Debug.Log("On Ground");
        }

        this.transform.rotation = myRotation;

    }
}
