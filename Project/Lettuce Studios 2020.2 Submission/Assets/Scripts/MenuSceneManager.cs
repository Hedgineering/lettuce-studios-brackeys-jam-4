using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject musicUi;
    public GameObject gamePlayUI;
    public GameObject exitBackToGamePlayScene;
    public GameObject settingsButtonFunction;

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


        if (settingsSceneOpen)
        {
            exitBackToGamePlayScene.SetActive(true);
           // settingsButtonFunction.SetActive(false);
        } else
        {
            exitBackToGamePlayScene.SetActive(false);
           // settingsButtonFunction.SetActive(true);
        }



    }
}
