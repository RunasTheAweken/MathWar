using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMovement : MonoBehaviour
{
    [SerializeField]
    private float searchRadius = 10f; 
    [SerializeField]
    [Range(0,100)]
    private float moveSpeed = 5f; // Скорость движения к цели
    [SerializeField]
    private float distanceToAvoid;
    private Animator unitAnimator;

    public LayerMask layerTarget;

    private RangeAttack attackScript;
    [SerializeField]
    private GameObject currentTarget;
    private float distanceToTarget;

    private bool isWaiting = false;

    private void Start()
    {
        unitAnimator = GetComponent<Animator>();
        attackScript = GetComponent<RangeAttack>();
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius, layerTarget); // Находим коллайдеры в радиусе
        
        Transform targetTransform = null;
        
        float nearestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            Transform colliderTransform = collider.transform;
            if (colliderTransform != transform && colliderTransform.tag != gameObject.tag && colliderTransform.tag != "GameRule") // Проверяем, чтобы юнит не был целью
            {
                float distance = Vector2.Distance(transform.position, colliderTransform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    targetTransform = colliderTransform;
                }                
            }
        }
        if (targetTransform != null)
        {
            // Конкретезируем
            Vector2 targetPosition = targetTransform.position;

            currentTarget = targetTransform.gameObject;
            DrawAI(targetPosition);
            LookAtCurrentTarget();
            float distance = Vector2.Distance(transform.position, currentTarget.transform.position);
            
            if (distance < distanceToAvoid)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, -moveSpeed * Time.deltaTime);
                unitAnimator.SetBool("IsAttack", false);
                attackScript.enabled = false;
                unitAnimator.SetBool("IsWalk", true);
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                if (!isWaiting)
                {
                    SetCurrentTarget(currentTarget); // Установить текущую цель в RangeMovement
                    StartCoroutine(AttackAfterDelay(2f));
                }
            }
        }
        else // Цель не найдена
        {
            SetCurrentTarget(null); // Обнулить текущую цель в RangeMovement
            unitAnimator.SetBool("IsAttack", false);
        }
    }

    public void SetCurrentTarget(GameObject target)
    {
        currentTarget = target;
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
        float targetTransformX = currentTarget.transform.position.x;
        if (transform.position.x < targetTransformX)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);  
        }
    }

    private IEnumerator AttackAfterDelay(float delay)
    {
        isWaiting = true;
        yield return new WaitForSeconds(delay);

        unitAnimator.SetBool("IsAttack", true);
        unitAnimator.SetBool("IsWalk", false);
        attackScript.enabled = true;

        isWaiting = false;
    }

    void DestroyThisUnit()
    {
        Destroy(gameObject);
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }
}
