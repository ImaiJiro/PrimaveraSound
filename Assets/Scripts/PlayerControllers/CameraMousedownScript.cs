using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMousedownScript : MonoBehaviour
{
    // I didn't write this!
    // Credit to https://forum.unity.com/threads/how-do-i-make-a-cinemachinefreelook-orbiting-camera-that-only-orbits-when-the-mouse-key-is-down.527634/#post-3468444


    // Start is called before the first frame update
    void Start()
    {
        // Bind Cinemachine Axes to the project's Axes
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    // function to return an axis only if right mouse button is down
    public float GetAxisCustom(string axisName)
    {
        // when Cinemachine tries accessing Mouse X
        if (axisName == "Mouse X")
        {
            // it will only return if right mouse button is pressed
            if (Input.GetMouseButton(1))
            {
                return Input.GetAxis("Mouse X");
            }

            // otherwise it will return empty
            else
            {
                return 0;
            }
        }

        // when cinemachine tries accessing Mouse Y
        else if (axisName == "Mouse Y")
        {
            // it will only return if right mouse button is pressed
            if (Input.GetMouseButton(1))
            {
                return Input.GetAxis("Mouse Y");
            }

            // otherwise it will return empty
            else
            {
                return 0;
            }
        }
        // when Cinemachine tries accessing a different Axis other than Mouse X and Mouse Y, return it
        return Input.GetAxis(axisName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
