using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource soundFX;
    public AudioSource musicFX;

    public void MusicVolumeSet(float _volume)
    {
        musicFX.volume = _volume;
        AudioLevels.musicVol = _volume;
    }

    public void EffectsVolumeSet(float _volume)
    {
        soundFX.volume = _volume;
        AudioLevels.effectsVol = _volume;
    }

}