using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public Transform PointToShoot;
    private RangeMovement movement;
    [SerializeField]
    private float TBS;
    
    [SerializeField]
    private int damage;

    [SerializeField]
    private GameObject Projectile;
    private GameObject currentProjectile;
    private Animator Animator;
    
    void Start()
    {
        Animator = GetComponent<Animator>();
        movement = GetComponent<RangeMovement>();
    }

    void Attack()
    {
        if (movement.GetCurrentTarget() != null || movement.GetCurrentTarget().Equals(gameObject))
        {
            currentProjectile = Instantiate(Projectile, PointToShoot.position, transform.rotation);
            currentProjectile.GetComponent<Projectile>().rangeMovement = movement;
        }
        else
        {
            movement.SetCurrentTarget(null);
        }
    }


}
