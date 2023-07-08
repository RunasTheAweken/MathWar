using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndSoundConfiguration : MonoBehaviour
{
    private const string MusicVolumePref = "MusicVolume";
    private const string SFXVolumePref = "SFXVolume";
    public AudioSource musicSource;

    public Scrollbar SFX;
    public Scrollbar Music;

    private CharacterSoundManager characterSoundManager;

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumePref, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFXVolumePref, 1f);

        Music.value = PlayerPrefs.GetFloat(MusicVolumePref, 1f);
        SFX.value = PlayerPrefs.GetFloat(SFXVolumePref, 1f);

        characterSoundManager = CharacterSoundManager.Instance;
    }

    public void SetMusicVolume()
    {
        musicSource.volume = Music.value;
        PlayerPrefs.SetFloat(MusicVolumePref, Music.value);
    }
    public void SetSFXVolume()
    {
        StartCoroutine(SetSFXVolumeNextFrame());
    }
    private IEnumerator SetSFXVolumeNextFrame()
    {
        yield return null; // wait until the next frame
        CharacterSoundManager.Instance.SetSFXVolumeForAllCharacters(SFX.value);
        PlayerPrefs.SetFloat(SFXVolumePref, SFX.value);
    }

}
