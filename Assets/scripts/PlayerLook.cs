using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xrotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void processLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        xrotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xrotation = Mathf.Clamp(xrotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        transform.Rotate(Vector3.up*(mouseX*Time.deltaTime)*xSensitivity);
    }

}
