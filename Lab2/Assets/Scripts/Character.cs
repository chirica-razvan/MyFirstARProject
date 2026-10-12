using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator mAnimator;
    public int hp = 100;
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
        if(hp <= 0)
        {
            hp = 100;
            attackInProgress = false;
            healthBar.UpdateHealthbar(hp);
            this.gameObject.SetActive(false);
            transform.parent.Find("Skull").gameObject.SetActive(true);
        }

    }
    private void OnEnable()
    {
        attackInProgress = false;

        if (mAnimator == null)
            mAnimator = GetComponent<Animator>();

        mAnimator.ResetTrigger("Attack");
        mAnimator.Rebind();
        mAnimator.Update(0f);
    }

    public void MakeAttack(Character target)
    {
        if (attackInProgress || target == null || !target.gameObject.activeInHierarchy)
            return;

        if (!attackInProgress)
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
