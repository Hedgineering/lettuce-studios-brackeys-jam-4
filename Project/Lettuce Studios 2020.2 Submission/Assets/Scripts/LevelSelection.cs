using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public AudioSource lvlAudioSource;
    public AudioClip clickedClip;
    public AudioClip hoveringClip;

    public void HoverClip()
    {
        lvlAudioSource.PlayOneShot(hoveringClip);
    }

    public void ClickClip()
    {
        lvlAudioSource.PlayOneShot(clickedClip);
    }
}
