using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAI : MonoBehaviour
{
    private GameObject pointToGo;
    private RangeMovement movement;

     private void Awake(){
        pointToGo = GameObject.Find("PointToGo");
        movement = GetComponent<RangeMovement>();
    }
    void Update()
    {
        if(movement.GetCurrentTarget() == null)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToGo.transform.position, movement.GetMoveSpeed() * Time.deltaTime);
            transform.localScale = new Vector3(-1,1,1);
            gameObject.GetComponent<Animator>().SetBool("IsWalk", true);
            if(transform.position == pointToGo.transform.position)
            {
                gameObject.GetComponent<Animator>().SetBool("IsWalk", false);
                Destroy(this);
            }
        }
    }
}
