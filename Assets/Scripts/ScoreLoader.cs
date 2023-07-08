using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLoader : MonoBehaviour
{
    public TMP_Text right;
    public TMP_Text wrong;
    private void Start() {
        right.text = PlayerPrefs.GetInt("RightAnswer").ToString();
        wrong.text = PlayerPrefs.GetInt("WrongAnswer").ToString();
    }
}
