using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CredToMenu : MonoBehaviour
{
    void Start()
    {
        // When the script starts, begin the coroutine that waits and then loads the menu
        StartCoroutine(ProceedingToMenu());
    }

    // Coroutine that waits for 10 seconds before changing the scene
    IEnumerator ProceedingToMenu()
    {
        // Wait for 10 seconds (credits screen duration)
        yield return new WaitForSeconds(10);

        // Load the first scene in the Build Settings (index 0, usually Main Menu)
        SceneManager.LoadScene(0);
    }
}
