using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    // Stores the player's saved progress point (loaded from PlayerPrefs)
    public int playerSavePoint;

    // Audio source that plays when a button is selected
    public AudioSource buttonSelect;

    // UI element used for fade-out effect when changing scenes
    public GameObject fadeOut;

    // UI element that blocks other button clicks during transitions
    public GameObject buttonBlocker;

    void Start()
    {
        // Load the player's last save position from PlayerPrefs
        // (default = 0 if no save exists)
        playerSavePoint = PlayerPrefs.GetInt("SavePosition");
    }

    void Update()
    {
        // Currently unused, but available for menu updates if needed
    }

    // Called when the "New Game" button is pressed
    public void NewGame()
    {
        StartCoroutine(NewStart());
    }

    // Coroutine to start a new game with transition effects
    IEnumerator NewStart()
    {
        buttonBlocker.SetActive(true);   // Block other buttons
        buttonSelect.Play();             // Play button sound
        fadeOut.SetActive(true);         // Trigger fade-out animation
        yield return new WaitForSeconds(3); // Wait for animation/sound
        SceneManager.LoadScene(1);       // Load scene index 1 (New Game scene)
    }

    // Called when the "Load Game" button is pressed
    public void LoadGame()
    {
        // Only allow loading if a save exists
        if (playerSavePoint == 1)
        {
            StartCoroutine(LoadStart());
        }
    }

    // Coroutine to load saved game with transition effects
    IEnumerator LoadStart()
    {
        buttonBlocker.SetActive(true);
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2); // Load scene index 2 (Saved Game scene)
    }

    // Called when the "Trophies" button is pressed
    public void TrophyMenu()
    {
        StartCoroutine(TrophyStart());
    }

    // Coroutine to load the Trophy Menu with transition effects
    IEnumerator TrophyStart()
    {
        buttonBlocker.SetActive(true);
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3); // Load scene index 3 (Trophy Menu)
    }

    // Called when the "Credits" button is pressed
    public void Credits()
    {
        StartCoroutine(CredStart());
    }

    // Coroutine to load the Credits scene with transition effects
    IEnumerator CredStart()
    {
        buttonBlocker.SetActive(true);
        buttonSelect.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4); // Load scene index 4 (Credits)
    }
}
