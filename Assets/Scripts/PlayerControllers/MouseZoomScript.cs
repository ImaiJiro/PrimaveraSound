using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseZoomScript : MonoBehaviour
{
    // Camera and default variables
    private CinemachineFreeLook playerTPCameraController;
    private float[] defaultHeights = new float[3];
    private float[] defaultOrbits = new float[3];
    private float defaultYAxis;
    private float defaultXAxis;

    // Zoom variables
    private float deltaZoom = 0f;
    public float cameraZoom = 0f;
    public float zoomRate;

    // Start is called before the first frame update
    void Start()
    {
        // bind the camera
        playerTPCameraController = GetComponent<CinemachineFreeLook>();


        // save the TP camera's default axes, heights, and orbits
        defaultYAxis = playerTPCameraController.m_YAxis.Value;
        defaultXAxis = playerTPCameraController.m_XAxis.Value;

        for(int i = 0; i < 3; i++)
        {
            defaultHeights[i] = playerTPCameraController.m_Orbits[i].m_Height;
            defaultOrbits[i] = playerTPCameraController.m_Orbits[i].m_Radius;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // get the change in zoom this frame
        deltaZoom += Input.GetAxisRaw("Mouse ScrollWheel") * (zoomRate * 100);

        // increment the cumulative zoom by the change
        cameraZoom += deltaZoom;
        cameraZoom = Mathf.Clamp(cameraZoom, 0f, 8f);

        // set the TPPCamera's radii and height using the cumulative zoom
        // clamped so that it cannot "invert", which is the default CM behavior if you scroll in/out too much
        // note that this ONLY applies to the Top and Middle rigs - the bottom will always remain stable
        // Only do so if the cameraZoom is not at the min or max values
        
        if (cameraZoom < 8 && cameraZoom > -2)
        {
            for (int i = 0; i < 2; i++)
                {

                    // set height
                    playerTPCameraController.m_Orbits[i].m_Height = Mathf.Clamp((playerTPCameraController.m_Orbits[i].m_Height += deltaZoom), defaultHeights[i]/2f, defaultHeights[i]*2f);

                    // set radius
                    playerTPCameraController.m_Orbits[i].m_Radius = Mathf.Clamp((playerTPCameraController.m_Orbits[i].m_Radius += deltaZoom), defaultOrbits[i] / 2f, defaultOrbits[i]*2f);

                }
        }
        
        

        // reset the change in zoom so it doesn't carry over to the next frame
        deltaZoom = 0;

        // camera resetting moved to ManagerScript
        

    }

    public void ResetCamera()
    {
        // Camera Reset
        
        // Reset the camera's height and radii (z value, ie distance from player)
        for (int i = 0; i < 3; i++)
        {
            playerTPCameraController.m_Orbits[i].m_Height = defaultHeights[i];
            playerTPCameraController.m_Orbits[i].m_Radius = defaultOrbits[i];
        }

        // recenter the camera's x and y values (height and position around the player)
        playerTPCameraController.m_YAxis.Value = defaultYAxis;
        playerTPCameraController.m_XAxis.Value = defaultXAxis;

        cameraZoom = 0f;
    }
}
