using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerMovment : MonoBehaviour
{
    [SerializeField]
    private float searchRadius = 10f; 
    [SerializeField]
    [Range(0,100)]
    private float moveSpeed = 5f; // Скорость движения к цели
    [SerializeField]
    private float DistanceToAvoid;
    private Animator UnitAnimator;

    public LayerMask layerTarget;


    public GameObject currentTarget;

    public bool CloseToTarget;
    private void Start() {
        UnitAnimator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius); // Находим коллайдеры в радиусе

        Transform targetTransform = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            Transform colliderTransform = collider.transform;
            if (colliderTransform != transform && colliderTransform.gameObject.tag == gameObject.tag)
            {
                float distance = Vector2.Distance(transform.position, colliderTransform.position);
                if (collider.TryGetComponent(out HP friendUnitHP))
                {
                    if (distance < nearestDistance && friendUnitHP.CurrentHealth < friendUnitHP.GetMaxHP() && friendUnitHP.gameObject.name != "HitPoint")
                    {
                        nearestDistance = distance;
                        targetTransform = colliderTransform;
                    }
                }
            }
        }
        if (targetTransform != null)
        {
            // Конкретезируем
            Vector2 targetPosition = targetTransform.position;

            currentTarget = targetTransform.gameObject;

            // Дистанция между ближайшим и юнитом
            float DistanceToTheTarget = Vector2.Distance(transform.position, targetPosition);
            
            if(DistanceToTheTarget > DistanceToAvoid){
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                CloseToTarget = false;
                UnitAnimator.SetBool("IsWalk", true);
            }
            else
            {
                UnitAnimator.SetBool("IsAttack", true);
                CloseToTarget = true;
            }
            LookAtCurrentTarget();
            UnitAnimator.SetBool("IsWalk", !CloseToTarget);
            DrawAI(targetPosition);
        }
        else
        {
            CloseToTarget = false;
            UnitAnimator.SetBool("IsAttack", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
    private void DrawAI(Vector2 targetPosition)
    {
        Debug.DrawLine(transform.position, targetPosition, Color.green);
    }
    private void LookAtCurrentTarget()
    {
        float TargetTransformX = currentTarget.transform.position.x;
        if(transform.position.x < TargetTransformX)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);  
        }

    }
}
