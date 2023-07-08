using UnityEngine.UI;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int CurrentHealth;
    public GameObject obj;
    private int MaxHealth;
    private Animator Animator;


    private void Start() {
     MaxHealth = CurrentHealth;
     Animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if(CurrentHealth <= 0)
        {
            Animator.SetBool("IsDead", true);
        }
    }


    public void TakeDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
    }
    public void GetHealed(int heal)
    {   
        CurrentHealth = CurrentHealth + heal;
    }
    public int GetMaxHP()
    {
        return MaxHealth;
    }
    void DestroyThisObject()
    {
        Destroy(gameObject);
    }
    void DestroyObject()
    {
        Destroy(obj);
    }
}
