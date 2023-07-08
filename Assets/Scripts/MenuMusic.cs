using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuMusic : MonoBehaviour
{
    public Scrollbar Music;
    public AudioSource musicSource;
    public void SetMusicVolume()
    {
        musicSource.volume = Music.value;
        PlayerPrefs.SetFloat("MusicVolume", Music.value);
    }
}
