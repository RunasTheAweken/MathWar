using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundManager : MonoBehaviour
{
    public static CharacterSoundManager Instance;

    private List<CharacterSound> characterSounds = new List<CharacterSound>();

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterSound(CharacterSound sound)
    {
        characterSounds.Add(sound);
        Debug.Log('s');
    }

    public void UnregisterSound(CharacterSound sound)
    {
        characterSounds.Remove(sound);
        Debug.Log('d');
    }

    public IEnumerable<CharacterSound> GetSounds()
    {
        return characterSounds;
    }
    public void SetSFXVolumeForAllCharacters(float value)
    {
        foreach(CharacterSound characterSound in characterSounds)
        {
            characterSound.SetVolume(value);
        }
    }

}
