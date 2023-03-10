using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMovementScript : MonoBehaviour
{
    public CharacterController playerController;
    public Transform playerCamera;

    public float moveSpeed = 6f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        // Get input axes (a and d for wasd, but can be changed in input settings)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // Create a vector out of player input
        // Only x and z because we don't want the player to fly around on y axis
        // Normalized to ensure the value of the Vector is always 1
        // That way, pressing two keys at once won't compound your speed
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Check movement
        // if the magnitude (length) of the direction vector is substantial enough, move the player
        if (direction.magnitude >= 0.1f)
        {
            // Make the player face the direction they're moving in
            // find the angle the player is moving at via Atan2 function
            // Atan2 returns in radians, so multiply by Rad2Deg to get degrees
            // then add playercamera's euler y to make the player move in the direction of the camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            // Rotate the player smoothly so they don't immediately snap to the direction of movement
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Apply rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            // find the direction the camera is facing
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // make player move in a combination of the direction the camera is facing and the direction of their input with a speed of moveSpeed
            // using Time.deltaTime to make it framerate-independant
            playerController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }

    }
}
