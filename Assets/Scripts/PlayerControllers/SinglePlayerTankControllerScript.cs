using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerTankControllerScript : MonoBehaviour
{
    // Player bocy variables
    public Rigidbody playerRigidbody;
    public bool walking;
    public Transform playerTrans;

    // Movement variables, in order:
    // walking/jogging speed, backwalking/backjogging speed, old walking/jogging speed, sprint speed, and rotate speed
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;

    // Player animator, will deal will use this later
    // public Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {

    }


   // FixedUpdate is called once per timestep
    private void FixedUpdate()
    {
        // Movement Code
        // If player is pressing W, make them move forward with walking speed
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.velocity = transform.forward * w_speed * Time.deltaTime;
        }
        // If playe ris pressing S, make them move backwards with backwalking speed
        if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
    }



    // Update is called once per frame
    void Update()
    {
        // TODO: Put in animation code?
        // Maybe the animator can handle all the conditions as well so no code will be needed, will have to look into that

        // Sprinting Code
        // if player is pressing W, they are walking
        if (Input.GetKeyDown(KeyCode.W))
        {
            walking = true;
        }
        // if player is not pressing w, they are not walking
        if (Input.GetKeyUp(KeyCode.W))
        {
            walking = false;
        }


        // Player Rotation
        // if player presses A, rotate them to the left with rotation speed
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        // if player presses D, rotate them to the right with rotation speed
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        // Sprinting Code
        // if the player is walking
        if (walking == true)
        {
            // if shift is down, add run speed to walk speed, and fixedupdate will use that new faster speed instead of the walk speed
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                w_speed += rn_speed;
            }
            // if shift is up, ensure that walking speed is the regular walking speed
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                w_speed = olw_speed;
            }
        }
    }
}
