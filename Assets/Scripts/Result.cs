
using UnityEngine;  

public class Result : MonoBehaviour
{
    public ScoreHolder score;
    public GameObject deadImage;
    public Timer timer;
    public Timer timerIgnore;


    void ShowResult()
    {
        timerIgnore.enabled = false;
        timer.enabled = false;
        score.ResultToText();
        deadImage.SetActive(true);
        Time.timeScale = 0f;
    }

}
