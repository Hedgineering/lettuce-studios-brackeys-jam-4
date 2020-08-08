using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    private static AudioClip[] playlist = new AudioClip[11];
    private static AudioClip endMusic;

    private void Awake()
    {
        playlist[0] = Resources.Load("Music/Tintamare_-_01_-_Ma_Tropicalit") as AudioClip;
        playlist[1] = Resources.Load("Music/Tintamare_-_02_-_Caracas") as AudioClip;
        playlist[2] = Resources.Load("Music/Tintamare_-_03_-_Knowlesville") as AudioClip;
        playlist[3] = Resources.Load("Music/Tintamare_-_04_-_Propane") as AudioClip;
        playlist[4] = Resources.Load("Music/Tintamare_-_05_-_Tannant") as AudioClip;
        playlist[5] = Resources.Load("Music/Tintamare_-_06_-_La_Fin_des_Haricots") as AudioClip;
        playlist[6] = Resources.Load("Music/Peyruis - Swing [Electro SwingDance] [CC BY]") as AudioClip;
        playlist[7] = Resources.Load("Music/The Hikers - Le Swing [Electro Swing] [CC BY]") as AudioClip;
        playlist[8] = Resources.Load("Music/The Musical Ghost - Potato Chips [Electro Swing] [CC BY]") as AudioClip;
        playlist[9] = Resources.Load("Music/Amarià - Lovely Swindle [Electro Swing] [CC BY]") as AudioClip;
        playlist[10] = Resources.Load("Music/EndMusic") as AudioClip;

        endMusic = playlist[10];
    }


    //You may only change the last slot publicly
    public static void setClip(AudioClip clip)
    {
        playlist[10] = clip;
    }

    public static AudioClip getClip(int i)
    {
        return playlist[i];
    }

    public static void ResetPlaylist()
    {
        playlist[10] = endMusic;
    }

    public static void Print()
    {
        int index = 0;
        foreach(AudioClip i in playlist)
        {
            print("Index " + index + ": " + i.name);
            index++;
        }
    }
}
