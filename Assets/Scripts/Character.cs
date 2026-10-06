using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator mAnimator;
    public int hp = 100;
    private bool attackInProgress = false;
    
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
            targetScript.hp -= 1;

        attackInProgress = false;
    }
}
