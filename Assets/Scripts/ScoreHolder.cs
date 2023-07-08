using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    public int RightAnswer;
    public int WrongAnswer;
    public TMP_Text right;
    public TMP_Text wrong;




    public void ResultToText()
    {
        PlayerPrefs.SetInt("RightAnswer", RightAnswer);
        PlayerPrefs.SetInt("WrongAnswer", WrongAnswer);
        right.text = RightAnswer.ToString();
        wrong.text = WrongAnswer.ToString();
    }

}
