using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed = 30;

    public float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * rotateSpeed * horizontalInput * Time.deltaTime);
    }
}
