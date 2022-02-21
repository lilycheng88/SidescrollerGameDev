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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 100), Mathf.Clamp(transform.position.y, 0, 0), transform.position.z);
        this.transform.rotation = myRotation;

    }
}
