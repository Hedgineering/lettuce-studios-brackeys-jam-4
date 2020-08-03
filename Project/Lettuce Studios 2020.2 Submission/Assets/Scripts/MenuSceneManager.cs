using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEditor.UI;

public class MenuSceneManager : MonoBehaviour
{
    public GameObject SettingsButtonGFX;
    public GameObject MusicButtonGFX;

    public GameObject settingsUI;
    public GameObject musicUi;
    public GameObject gamePlayUI;
    public GameObject exitBackToGamePlayScene;
    
    public bool musicScenOpen;
    public  bool settingsSceneOpen;
    public bool gamePlaySceneOpen;
   

    // Start is called before the first frame update
    void Start()
    {
        gamePlayUI.SetActive(true);
        settingsUI.SetActive(false);
        musicUi.SetActive(false);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        //This will change the bools based on the stuff thats happening
        if (!gamePlayUI.active) 
        {
            gamePlaySceneOpen = false;
        }
        else
        {
            gamePlaySceneOpen = true;
        }
        if (!musicUi.active)
        {
            musicScenOpen = false;
        }
        else
        {
            musicScenOpen = true;
        }
        if (!settingsUI.active)
        {
            settingsSceneOpen = false;
        }
        else
        {
            settingsSceneOpen = true;
        }
        //end of bool stuff

        //for settings ui
        if (settingsSceneOpen)
        {
            exitBackToGamePlayScene.SetActive(true);
            SettingsButtonGFX.GetComponent<>().isEnabled = false;
        } else
        {
            settingsUI.GetComponent<Button>().enabled = true;
        }
        //for music ui
        if (musicScenOpen)
        {
            exitBackToGamePlayScene.SetActive(true);
            musicUi.GetComponent<Button>().enabled = false;
        }
        else
        {
            musicUi.GetComponent<Button>().enabled = true;
        }
        //For main menuu ui
        if (gamePlaySceneOpen)
        {
                exitBackToGamePlayScene.SetActive(false);
        } 

    }
}
