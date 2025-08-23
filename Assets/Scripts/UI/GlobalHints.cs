using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHints : MonoBehaviour
{
    // Reference to the UI Text element that will display hints
    public GameObject hintText;

    // A static integer used as a trigger to determine which hint to show
    // (Can be changed from any script by calling GlobalHints.hintNumber = X)
    public static int hintNumber;

    void Update()
    {
        // If hintNumber is set to 1 (triggered elsewhere in the game)
        if (hintNumber == 1)
        {
            // Reset hintNumber so the hint only shows once
            hintNumber = 0;

            // Set the hint text to the appropriate message
            hintText.GetComponent<Text>().text = 
                "Mission start points can be found by searching for the glowing orange points on your map.";

            // Toggle visibility off and on to refresh the UI (forces the text to update)
            hintText.SetActive(false);
            hintText.SetActive(true);
        }

        // If hintNumber is set to 2
        if (hintNumber == 2)
        {
            // Reset hintNumber so the hint only shows once
            hintNumber = 0;

            // Set the hint text to the driving instructions
            hintText.GetComponent<Text>().text = 
                "Press W to drive forward and press S to reverse the vehicle.";

            // Toggle visibility off and on to refresh the UI
            hintText.SetActive(false);
            hintText.SetActive(true);
        }
    }
}
