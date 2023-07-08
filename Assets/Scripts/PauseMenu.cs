using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool StopGame = false;

    public void Pause()
    {
        StopGame = !StopGame;
        pauseMenuUI.SetActive(StopGame);
        if(StopGame == true)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
