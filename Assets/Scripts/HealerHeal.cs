using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerHeal : MonoBehaviour
{

    [SerializeField]
    private int Heal;
    private HealerMovment movment;

    private void Start() {
        movment = GetComponent<HealerMovment>();
    }


    void HealUnit()
    {
        if(movment.currentTarget.GetComponent<HP>() != null){
        HP Friendhp = movment.currentTarget.GetComponent<HP>();
        Friendhp.GetHealed(Heal);
        }
    }

}
