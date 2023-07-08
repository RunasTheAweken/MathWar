using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private MeleeMovment movment;
    public int damage;

    private Animator Animator;
    private bool isAttacking = false; // Флаг для отслеживания состояния атаки

    void Start()
    {
        Animator = GetComponent<Animator>();
        movment = GetComponent<MeleeMovment>();
    }
    void FixedUpdate()
    {
        if (movment.currentTarget != null && movment.currentTarget != this.gameObject && !isAttacking && movment.CloseToTarget)
        {
            isAttacking = true;
            Animator.SetBool("IsAttack", isAttacking);// 1 ПЕРЕДВИЖЕНИЕ 2 АТАКА 3 СМЕРТЬ
        }
        else if ((movment.currentTarget == null || movment.currentTarget == this.gameObject) && isAttacking && !movment.CloseToTarget)
        {
            isAttacking = false;
        }
    }

    void Attack()
    {
        if(movment.currentTarget != null){
        HP Enemyhp = movment.currentTarget.GetComponent<HP>();
        Enemyhp.TakeDamage(damage);
        }
    }

}
