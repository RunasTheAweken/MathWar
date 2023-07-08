using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Transform MyPlace;
    public Transform EnemyPlace;
    public Transform EnemyPlaceHealer;

    public GameObject[] MyCharacters;
    public GameObject[] EnemyCharacters;
    
    public void SpawnMyCharacter(int index)
    {
        Instantiate(MyCharacters[index], MyPlace.transform.position, MyPlace.transform.rotation);
    }
    public void SpawnEnemyCharacter()
    {
        int index = Random.Range(0,2);
        switch(index)
        {
            case 0:
            Instantiate(EnemyCharacters[0], EnemyPlace.transform.position, EnemyPlace.transform.rotation);
            break;
            case 1:
            Instantiate(EnemyCharacters[1], EnemyPlace.transform.position, EnemyPlace.transform.rotation);
            break;
            case 2:
            Instantiate(EnemyCharacters[2], EnemyPlace.transform.position, EnemyPlace.transform.rotation);
            break;
        }        
    }
}
