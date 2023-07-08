using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    public AudioSource SpawnSound;
    public AudioSource AttackSound;
    public AudioSource Footstepsounds;

    private void OnEnable() 
    {
        CharacterSoundManager.Instance.RegisterSound(this);
    }

    private void OnDisable() 
    {
        CharacterSoundManager.Instance.UnregisterSound(this);
    }

    private void Start() 
    {
        SpawnSound.Play();
    }

    public void AttackSoundPlay()
    {
        AttackSound.Play();
    }

    public void FootstepPlay()
    {
        Footstepsounds.pitch = Random.Range(1,1.5f);
        Footstepsounds.Play();
    }

    public void SetVolume(float value)
    {   
        SpawnSound.volume = value;
        AttackSound.volume = value;
        Footstepsounds.volume = value;
    }
}
