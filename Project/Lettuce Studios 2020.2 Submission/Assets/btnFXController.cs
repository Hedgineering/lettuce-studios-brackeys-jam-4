using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnFXController : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        myFx.PlayOneShot (hoverFx);
    }
    public void Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 ); 
        myFx.PlayOneShot (clickFx);
    }
}
