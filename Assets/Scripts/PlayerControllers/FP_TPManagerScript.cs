using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_TPManagerScript : MonoBehaviour
{
    // variables
    public GameObject playerTPContainer;
    public GameObject playerFPCamera;
    public TPMovementScript playerTPMovement;
    public FPMovementScript playerFPMovement;
    public MouseZoomScript mouseZoomScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // since both TP and FP cameras require RMB to be pressed, lock and hide the cursor when this is the case
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        // Since MetaHype will be replacing this movement code anyway,
        // I have not bothered having a "scroll in-to first person" system (like skyrim, for example)
        // instead, Z puts you in First Person and C puts you in Third Person (configurable in Project Settings)

        // enable Third Person
        if (Input.GetAxis("Third Person") == 1)
        {
            // disable first person camera and movement scheme
            playerFPCamera.SetActive(false);
            playerFPMovement.enabled = false;

            // enable Third Person Cameras and movement scheme
            playerTPContainer.SetActive(true);
            playerTPMovement.enabled = true;

            // reset the camera
            mouseZoomScript.ResetCamera();
        }

        // enable First Person
        if (Input.GetAxis("First Person") == 1)
        {
            // disable Third Person Cameras and movement scheme
            playerTPContainer.SetActive(false);
            playerTPMovement.enabled = false;

            // enable first person camera and movement scheme
            playerFPCamera.SetActive(true);
            playerFPMovement.enabled = true;
        }

    }
}
