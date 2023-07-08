using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathGenerator : MonoBehaviour
{
    int firstNumber, secondNumber, answerNumber;
    private int ChooseQuestion;
    private int rightAnswer;
    public TMP_Text Question;
    public TMP_Text[] Answers;


    private void Start() {
        GenerateNewQuestion();
    }


    public void GenerateNewQuestion()
    {
        int RandomGenerate = Random.Range(1,4);
        switch(RandomGenerate)
        {
            case 1:
            DoMathPositive();
            break;
            case 2:
            DoMathNegative();
            break;
            case 3:
            DoMathMultimply();
            break;
            case 4:
            DoMathDevide();
            break;
        }
    }
    void GenerateAnswers()
    {
        int[] tempAnswers = new int[3];

        for (int i = 0; i < tempAnswers.Length; i++)
        {
            int newAnswer;
            do
            {
                newAnswer = Random.Range(0, 9);
            } while (System.Array.IndexOf(tempAnswers, newAnswer) != -1 || newAnswer == rightAnswer);

            tempAnswers[i] = newAnswer;
            Answers[i].text = newAnswer.ToString();
        }

        int random = Random.Range(0, 3);
        Answers[random].text = rightAnswer.ToString();
    }


    void DoMathNegative()
    {
        secondNumber = Random.Range(0,9);
        firstNumber = Random.Range(secondNumber,9);
        Question.text = firstNumber.ToString()+ " - " + secondNumber.ToString() + " " + "=" + " ?";
        rightAnswer = firstNumber - secondNumber;
        GenerateAnswers();
    }
    void DoMathPositive()
    {
        secondNumber = Random.Range(0,9);
        firstNumber = Random.Range(0,9);
        Question.text = firstNumber.ToString()+ " + " + secondNumber.ToString() + " " + "=" + " ?";
        rightAnswer = firstNumber + secondNumber;
        GenerateAnswers();
    }
    void DoMathMultimply()
    {
        secondNumber = Random.Range(0,9);
        firstNumber = Random.Range(0,9);
        Question.text = firstNumber.ToString()+ " * " + secondNumber.ToString() + " " + "=" + " ?";
        rightAnswer = firstNumber * secondNumber;
        GenerateAnswers();
    }
    void DoMathDevide()
    {
        secondNumber = Random.Range(1,9);
        firstNumber = Random.Range(1,9);
        while (firstNumber % secondNumber != 0 || firstNumber == secondNumber || secondNumber == 1)
        {
            firstNumber = Random.Range(1,9);
            secondNumber = Random.Range(1,9);
        }
        Question.text = firstNumber.ToString()+ " / " + secondNumber.ToString() + " " + "=" + " ?";
        rightAnswer = firstNumber / secondNumber;
        GenerateAnswers();
    }
    public int GetRightAnswer()
    {
        return rightAnswer;
    }
}
