using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA_Opening : MonoBehaviour {

    // References to UI elements, cameras, and player objects
    public GameObject fadeIn;         // Fade-in UI overlay
    public GameObject theText;        // Intro text displayed at start
    public GameObject initialCamera;  // Camera used for intro cutscene
    public GameObject fadeOut;        // Fade-out UI overlay
    public GameObject thePlayer;      // Player character object
    public GameObject killerFake;     // Fake killer object shown in intro
    public GameObject cashCount;      // UI for cash display
    public GameObject ammoCount;      // UI for ammo display
    public GameObject hintBox;        // UI for hints
    public GameObject miniMap;        // UI for minimap

    void Start () {
        // Start the opening sequence coroutine
        StartCoroutine(OpenBegin());
    }

    // Coroutine controlling the opening cutscene sequence
    IEnumerator OpenBegin()
    {
        // Hide and lock the cursor during the cutscene
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSeconds(1); // Small delay before starting

        // Display intro text
        theText.SetActive(true);
        yield return new WaitForSeconds(7); // Wait for player to read text

        // Enable fade-in animation and intro camera animation
        fadeIn.GetComponent<Animator>().enabled = true;
        initialCamera.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);

        // Trigger fade-out effect and hide the fade-in overlay
        fadeOut.SetActive(true);
        fadeIn.SetActive(false);
        yield return new WaitForSeconds(2.5f);

        // Hide the fake killer, enable the player, disable the intro camera
        killerFake.SetActive(false);
        thePlayer.SetActive(true);
        initialCamera.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        // Prepare the gameplay UI elements and fade-in overlay
        fadeOut.SetActive(false);
        fadeIn.SetActive(true);
        cashCount.SetActive(true);
        ammoCount.SetActive(true);
        hintBox.SetActive(true);
        miniMap.SetActive(true);

        // Play the fade-in animation for gameplay start
        fadeIn.GetComponent<Animator>().Play("FadeInAnim");
        yield return new WaitForSeconds(4);

        // Unlock the first trophy after the opening sequence
        TrophyManager.trophyUnlocker01 = 1;

        // Hide the fade-in overlay now that the cutscene is over
        fadeIn.SetActive(false);

        // Trigger the first hint to be displayed
        GlobalHints.hintNumber = 1;
    }
}
