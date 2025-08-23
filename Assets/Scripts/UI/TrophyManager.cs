using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyManager : MonoBehaviour
{
    // References to the UI/GameObjects for showing unlocked trophies
    public GameObject trophy01;
    public GameObject trophy02;

    // Sound effect that plays when a trophy is unlocked
    public AudioSource trophyUnlock;

    // Static variables used as "signals" from gameplay scripts
    // (set to 1 when a trophy condition is met, updated here when processed)
    public static int trophyUnlocker01;
    public static int trophyUnlocker02;

    // Stores the saved status of trophies (loaded from PlayerPrefs)
    // 0 = locked, 2 = unlocked
    public int trophyStatus01;
    public int trophyStatus02;

    // Keeps track of which trophy is being unlocked
    public int trophyCount;

    void Start()
    {
        // Load saved trophy statuses from PlayerPrefs
        trophyStatus01 = PlayerPrefs.GetInt("Trophy01");
        trophyStatus02 = PlayerPrefs.GetInt("Trophy02");
    }

    void Update()
    {
        // Check if trophy 01 should be unlocked
        if (trophyUnlocker01 == 1 && trophyStatus01 == 0)
        {
            // Save unlocked state in PlayerPrefs
            PlayerPrefs.SetInt("Trophy01", 2);

            // Mark as processed
            trophyUnlocker01 = 2;

            // Identify which trophy to show
            trophyCount = 1;

            // Start unlock animation/sound
            StartCoroutine(UnlockingTrophy());
        }

        // Check if trophy 02 should be unlocked
        if (trophyUnlocker02 == 1 && trophyStatus02 == 0)
        {
            // Save unlocked state in PlayerPrefs
            PlayerPrefs.SetInt("Trophy02", 2);

            // Mark as processed
            trophyUnlocker02 = 2;

            // Identify which trophy to show
            trophyCount = 2;

            // Update local status to prevent repeat unlock
            trophyStatus02 = 2;

            // Start unlock animation/sound
            StartCoroutine(UnlockingTrophy());
        }
    }

    // Return to Main Menu (scene index 0 in Build Settings)
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Coroutine to display trophy unlock popup temporarily
    IEnumerator UnlockingTrophy()
    {
        // Play trophy unlock sound
        trophyUnlock.Play();

        // If unlocking trophy 01
        if (trophyCount == 1)
        {
            trophy01.SetActive(true);  // Show trophy
            yield return new WaitForSeconds(5);
            trophy01.SetActive(false); // Hide after delay
        }

        // If unlocking trophy 02
        if (trophyCount == 2)
        {
            trophy02.SetActive(true);
            yield return new WaitForSeconds(5);
            trophy02.SetActive(false);
        }
    }
}
