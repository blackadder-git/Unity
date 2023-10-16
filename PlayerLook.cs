using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 1f;
    public float ySensitivity = 1f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;

        // keep head from spining around
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // apply to camera 
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // rotate left or right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
