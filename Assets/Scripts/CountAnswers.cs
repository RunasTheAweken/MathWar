using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountAnswers : MonoBehaviour
{
    public ScoreHolder score;
    public MathGenerator generator;
    public Animator SpawnCharacterAnimator;
    public CharacterManager manager;
    public Timer timer;

    private TMP_Text Answer;
    
    
    private void Start() {
        Answer = GetComponent<TMP_Text>();
    }

    public void CheckAnswer()
    {
        if(Answer.text == generator.GetRightAnswer().ToString())
        {
            score.RightAnswer++;
            SpawnCharacterAnimator.SetBool("IsActive", true);
            timer.timeRemaining = timer.GetMaxTime();
        }
        else
        {
            score.WrongAnswer++;
            manager.SpawnEnemyCharacter();
            generator.GenerateNewQuestion();
        }
    }
    public void SetAnimatorBoolFalse()
    {
        SpawnCharacterAnimator.SetBool("IsActive", false);
    }
}
