using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void loadScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
        Time.timeScale = 1;
    }
}
