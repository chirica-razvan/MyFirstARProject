using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator mAnimator;
    private int hp = 100;
    private volatile bool attackInProgress = false;
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

    public void MakeAttack(Character target)
    {
        if(!attackInProgress)
        {
            attackInProgress = true;
            StartCoroutine(AttackRoutine(target));
        }
    }
    
    private IEnumerator AttackRoutine(Character target)
    {
        attackInProgress = true;
        mAnimator.SetTrigger("Attack");

        // Wait one frame to let the trigger register and start transitioning
        yield return null; 

        // Wait until we are firmly in the Attack state
        while (!mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) 
        {
            yield return null;
        }

        // Wait until the animation is 70% complete (the sweet spot for the hit)
        while (mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f)
        {
            yield return null;
        }

        // Deal Damage once
        if (target != null) 
        {
            target.TakeDamage(20);
        }

        // Wait until the animation completely finishes
        while (mAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        attackInProgress = false;
    }
    
    void DealDamage(Character target)
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
