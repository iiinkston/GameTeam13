using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyLoader : MonoBehaviour
{
    // References to the trophy GameObjects that will be shown when unlocked
    public GameObject trophyUnlock01;
    public GameObject trophyUnlock02;

    // Values loaded from PlayerPrefs to check if trophies are unlocked
    public int unlocked01;
    public int unlocked02;

    // Counter for total number of trophies unlocked
    public int trophyCount;

    // UI Text element to display the total trophy count
    public GameObject trophyDisplay;

    void Start()
    {
        // Load saved unlock states from PlayerPrefs (default = 0 if not saved)
        unlocked01 = PlayerPrefs.GetInt("Trophy01");
        unlocked02 = PlayerPrefs.GetInt("Trophy02");

        // If Trophy 01 is unlocked (value 2 means unlocked), activate its GameObject and increase count
        if (unlocked01 == 2)
        {
            trophyUnlock01.SetActive(true);
            trophyCount += 1;
        }

        // If Trophy 02 is unlocked (value 2 means unlocked), activate its GameObject and increase count
        if (unlocked02 == 2)
        {
            trophyUnlock02.SetActive(true);
            trophyCount += 1;
        }

        // Update the UI to show how many trophies have been unlocked
        trophyDisplay.GetComponent<Text>().text = "" + trophyCount;
    }

    // Update is called once per frame (currently unused)
    void Update()
    {

    }
}
