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
            this.transform.LookAt(target.transform);
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
        while (!mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")&& 
               !mAnimator.GetCurrentAnimatorStateInfo(0).IsName("FinishAttack")) 
        {
            yield return null;
        }

        // Deal Damage once
        if (target != null) 
        {
            target.TakeDamage(20);
        }

        while (!mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            yield return null;
        }

        attackInProgress = false;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        healthBar.UpdateHealthbar(hp);
    }
}
