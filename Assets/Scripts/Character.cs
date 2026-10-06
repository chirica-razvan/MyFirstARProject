using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    private Animator mAnimator;
    private int hp = 100;
    private bool attackInProgress = false;
    [SerializeField] HealthBar healthBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    void MakeAttack(GameObject target)
    {
        if(!attackInProgress)
            if (mAnimator != null)
            {
                attackInProgress = true;
                mAnimator.SetTrigger("Attack");
            }

        DealDamage(target);
    }

    void DealDamage(GameObject target)
    {
        Character targetScript = target.GetComponent<Character>();
        while (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("FinishAttack"))
            targetScript.TakeDamage(1);

        attackInProgress = false;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        healthBar.UpdateHealthbar(hp);
    }
}
