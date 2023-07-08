using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public RangeMovement rangeMovement;
    [SerializeField]
    private int Damage;
    [SerializeField]
    private float speed;
    private GameObject Target;
    private Vector3 CurrentTargetPosition;

void Start()
{
    Target = rangeMovement.GetCurrentTarget(); // Исправлено на GetCurrentTarget()
    Vector3 TragetTransform = Target.transform.position + new Vector3(0, 1f, 0);
    Vector2 direction = TragetTransform - transform.position;
    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5);
}

    void Update()
    {
        if (Target != null)
        {
            Vector3 TragetTransform = Target.transform.position + new Vector3(0, 1f, 0);
            CurrentTargetPosition = TragetTransform;
            transform.position = Vector3.MoveTowards(transform.position, TragetTransform, speed * Time.deltaTime);
        }
        else
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
    

        GameObject OtherGameObject = other.gameObject;
        GameObject MyGameObject = rangeMovement.gameObject;

        // Проверка на null перед обращением к hp
        HP hp = other.gameObject.GetComponent<HP>();
        if (hp != null && OtherGameObject.tag != MyGameObject.tag)
        {
            hp.TakeDamage(Damage);
        }

        // Проверка на null перед обращением к Target
        if (other.gameObject.tag == "Projectile" || (Target != null && other.gameObject.tag == MyGameObject.tag))
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
