using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWanted : MonoBehaviour
{
    // Array of star GameObjects that represent the wanted level (UI elements)
    public GameObject[] wantedStars;

    // Flag to check if a star is currently being animated (prevents overlapping coroutines)
    public bool addingStar;

   
    public static int wantedLevel;

    // Trigger flag used to start adding a star
    public static bool activateStar;

    void Update()
    {
        // If not already animating a star and activateStar has been set true
        if (addingStar == false && activateStar == true)
        {
            // Reset the trigger and mark that we're animating
            activateStar = false;
            addingStar = true;

            // Start coroutine to animate the flashing star
            StartCoroutine(AddStar());
        }
    }

    // Coroutine that flashes the star multiple times to give a "blinking" effect
    IEnumerator AddStar()
    {
        // Blink the star on and off several times at 0.5s intervals
        wantedStars[wantedLevel - 1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);
        yield return new WaitForSeconds(0.5f);

        wantedStars[wantedLevel - 1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);
        yield return new WaitForSeconds(0.5f);

        wantedStars[wantedLevel - 1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);
        yield return new WaitForSeconds(0.5f);

        wantedStars[wantedLevel - 1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);
        yield return new WaitForSeconds(0.5f);

        wantedStars[wantedLevel - 1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wantedStars[wantedLevel - 1].SetActive(false);
        yield return new WaitForSeconds(0.5f);

        // Leave the star ON at the end of the animation
        wantedStars[wantedLevel - 1].SetActive(true);

        // Finished animating → allow future activations
        addingStar = false;
    }
}
