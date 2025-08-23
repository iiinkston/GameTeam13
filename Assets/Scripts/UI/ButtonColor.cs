using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    // Reference to the UI text (or GameObject) that indicates light status
    public GameObject lightText;

    // Called when the mouse enters the button area
    // Hides (deactivates) the lightText object
    public void TurnOff()
    {
        lightText.SetActive(false);
    }

    // Called when the mouse leaves the button area
    // Shows (activates) the lightText object
    public void TurnOn()
    {
        lightText.SetActive(true);
    }
}
