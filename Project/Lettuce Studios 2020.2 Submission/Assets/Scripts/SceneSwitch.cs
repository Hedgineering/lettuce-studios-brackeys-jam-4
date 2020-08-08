using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void loadScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
        Time.timeScale = 1;
    }
}
