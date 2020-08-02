using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverClip;
    public AudioClip clickClip;

    public void HoverClip()
    {
        audioSource.PlayOneShot(hoverClip);
    }

    public void ClickClip()
    {
        audioSource.PlayOneShot(clickClip);
    }
}
