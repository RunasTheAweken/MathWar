using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake() {
        Time.timeScale = 1f;    
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void EscapeGame()
    {
        Application.Quit();
    }
}
