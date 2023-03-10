using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCameraScript: MonoBehaviour
{
    // Variable
    public Transform playerTransform;
    public float mouseSensitivity = 2f;
    private float cameraVerticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float mouseInputX = 0f;
        float mouseInputY = 0f;


        // Collect Mouse Input only when RMB is down
        if (Input.GetMouseButton(1))
        {
            mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        }

        // Rotate the camera around it's local X axis
        // upwards rotation must be negetive, so we invert mouse input
        cameraVerticalRotation -= mouseInputY;
        
        // clamp the camera to values between -90 and 90 degrees
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        // rotate the camera
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        // Rotate the PLAYER around it's local Y axis according to mouse input
        // the camera is a child, so it will rotate with the player
        playerTransform.Rotate(Vector3.up * mouseInputX);
        
    }
}
