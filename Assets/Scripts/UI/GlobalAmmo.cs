using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    // A static variable to track the number of pistol shots available
    // (Static means it can be accessed from any other script without needing a reference)
    public static int pistolShots;

    // Reference to the UI Text element that displays the current ammo count
    public GameObject ammoDisplay;

    void Update()
    {
        // Update the ammo display text every frame to show the current pistolShots value
        ammoDisplay.GetComponent<Text>().text = "" + pistolShots;
    }
}
