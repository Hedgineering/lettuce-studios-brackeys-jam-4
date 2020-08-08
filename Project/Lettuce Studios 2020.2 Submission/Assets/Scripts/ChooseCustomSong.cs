using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using NAudio;
using NAudio.Wave;

public class ChooseCustomSong : MonoBehaviour
{
    public string path { get; private set; }
    private string outpath;
    public TextMeshProUGUI pathText;
    AudioSource song;
    AudioClip musicfile;

    private void Awake()
    {
        song = GetComponent<AudioSource>();
    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Choose your song", "", ".mp3");
        if (path != null && !path.Equals(""))
        {
            pathText.SetText(path);
            CreateOutPath(path);
            StartCoroutine(SetSong());
        }
        
    }

    public void ResetSelection()
    {
        pathText.SetText("SURVIVE: Highway at Night (Custom Made)");
        Playlist.ResetPlaylist();
    }

    private void CreateOutPath(string path)
    {
        string temp = path.LastIndexOf(".mp3") > 0 ? path.Substring(0, path.LastIndexOf(".mp3")) : "C:/song";
        outpath = temp + ".wav";
        //print(outpath);
    }

    IEnumerator SetSong()
    {
        if (path != null)
        {
            using (UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip("file:///" + path, AudioType.MPEG))
            {
                yield return unityWebRequest.SendWebRequest();

                if (unityWebRequest.isNetworkError)
                {
                    Debug.Log(unityWebRequest.error);
                }
                else
                {
                    //Converting MP3 to WAV because Unity won't play MP3 due to copyright issues
                    //song.clip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
                    using (var reader = new Mp3FileReader(path))
                    {
                        WaveFileWriter.CreateWaveFile(outpath, reader);

                        using (UnityWebRequest unityWebRequestWav = UnityWebRequestMultimedia.GetAudioClip("file:///" + outpath, AudioType.WAV))
                        {
                            yield return unityWebRequestWav.SendWebRequest();

                            if (unityWebRequest.isNetworkError)
                            {
                                Debug.Log(unityWebRequestWav.error);
                            }
                            else
                            {
                                Playlist.setClip(DownloadHandlerAudioClip.GetContent(unityWebRequestWav));
                                #region debugclip
                                //song.clip = DownloadHandlerAudioClip.GetContent(unityWebRequestWav);
                                //song.Play();
                                Playlist.Print();
                                //song.clip = Playlist.getClip(10);
                                //song.Play();
                                //print("clip assigned!");
                                #endregion debugclip
                            }
                        }

                    }
                }
            }
        }
    }
}
