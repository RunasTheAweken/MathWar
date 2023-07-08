using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 10;
    public MathGenerator generator;
    
    private float MaxtimeRemaing;
    private float normalizedtimeRemaing;
    public CharacterManager manager;
    public bool IgnoreAnswer;

    Image Circle;
    private void Start()
    {
        Circle = GetComponent<Image>();
        MaxtimeRemaing = timeRemaining;
    }

    void Update()
    {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Circle.fillAmount = GetNormolized();
            }
            else
            {
                timeRemaining = 0;
                if(IgnoreAnswer == true)
                {
                    manager.SpawnEnemyCharacter();
                }
                else
                {
                    generator.GenerateNewQuestion();
                    manager.SpawnEnemyCharacter();
                }
                timeRemaining = MaxtimeRemaing;
            }
    }

    private float GetNormolized()
    {
        normalizedtimeRemaing = timeRemaining / MaxtimeRemaing;
        return normalizedtimeRemaing;
    }
    public float GetMaxTime()
    {
        return MaxtimeRemaing;
    }
}
