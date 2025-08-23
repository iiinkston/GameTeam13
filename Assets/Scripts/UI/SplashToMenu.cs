using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{
    void Start()
    {
        // When the splash screen scene starts, begin the coroutine
        StartCoroutine(ProceedingToMenu());
    }

    // Coroutine that waits before loading the main menu
    IEnumerator ProceedingToMenu()
    {
        // Wait for 7 seconds (time to display splash screen/logo)
        yield return new WaitForSeconds(7);

        // Load the first scene in the Build Settings (index 0 → usually Main Menu)
        SceneManager.LoadScene(0);
    }
}
