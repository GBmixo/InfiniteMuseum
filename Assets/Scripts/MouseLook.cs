using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityX = 8f;
    public float sensitivityY = 0.5f;
    float mouseX, mouseY;

    public Transform playerCamera;
    public float xClamp = 85f;
    float xRotation = 0f;
    float yRotation = 0f;

    public void UpdateMouseInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    void Update()
    {
        //transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        yRotation += mouseX;

        Quaternion targetRotation = transform.rotation;

        Vector3 targetRotationModified = new Vector3(xRotation, yRotation, targetRotation.z);
        transform.eulerAngles = targetRotationModified;

        //transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

    }
}
