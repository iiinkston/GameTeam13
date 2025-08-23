using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationDisplay : MonoBehaviour
{
    // Reference to the UI GameObject that shows the location text on screen
    public GameObject locationDisplay;

    // The name of the location that will be displayed when the player enters the trigger
    public string locationName;

    // Triggered when another collider enters this object's trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.tag == "Player")
        {
            // Disable this collider so the trigger can’t be activated again immediately
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            // Update the location UI text with the current location name
            locationDisplay.GetComponent<Text>().text = locationName;

            // Play the "LocationDisplay" animation (fade in/out effect on the text)
            locationDisplay.GetComponent<Animator>().Play("LocationDisplay");

            // Start coroutine to reset the UI and re-enable the collider after a delay
            StartCoroutine(ResetLoc());
        }
    }

    // Coroutine that resets the location display after a delay
    IEnumerator ResetLoc()
    {
        // Wait for 7 seconds (time for the location display to be visible)
        yield return new WaitForSeconds(7);

        // Reset the animation to "New State" (usually the default idle state)
        locationDisplay.GetComponent<Animator>().Play("New State");

        // Re-enable the collider so this location can be triggered again later
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
