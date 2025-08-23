using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    // Reference to the player GameObject (the one this script controls)
    public GameObject thePlayer;

    // Flags and values for movement state
    public bool isRunning;                
    public float horizontalMove;          
    public float verticalMove;            

    // Footstep system
    public int stepNum;                  
    public static bool isStepping = false;
    public AudioSource footStep1;        
    public AudioSource footStep2;         

    void Update()
    {
        // Check if player is pressing movement input keys
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            // Play "Run" animation whenever the player is moving
            thePlayer.GetComponent<Animation>().Play("Run");

            // Get horizontal (rotation) and vertical (forward/backward) input values
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150; 
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 8;       

            // Set running flag
            isRunning = true;

            // If not already playing a footstep, start the coroutine to play sounds
            if (isStepping == false)
            {
                StartCoroutine(RunSound());
            }

            // Apply rotation and forward movement to the character
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0, 0, verticalMove);
        }
        else
        {
            // If the player is not firing or aiming, play idle animation
            if (FiringPistol.isFiring == false && FiringPistol.isAiming == false)
            {
                thePlayer.GetComponent<Animation>().Play("Idle");
                isRunning = false;
            }
        }
    }

    // Coroutine to handle footstep sounds while running
    IEnumerator RunSound()
    {
        // Only play if the player is running and not already stepping
        if (isRunning == true && isStepping == false)
        {
            isStepping = true;

            // Randomly pick between two footstep sounds
            stepNum = Random.Range(1, 3); 
            if (stepNum == 1)
            {
                footStep1.Play();
            }
            else
            {
                footStep2.Play();
            }
        }

        // Wait for 0.3 seconds before allowing the next footstep sound
        yield return new WaitForSeconds(0.3f);
        isStepping = false;
    }
}
