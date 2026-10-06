using UnityEngine;

public class Character : MonoBehaviour
{
    private Animator mAnimator;
    [SerializeField] private int secondsFromStart = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mAnimator.SetTrigger("Attack");
    }

    // Update is called once per frame
    void Update()
    { 
        if(mAnimator!=null)
            if(Input.GetKeyDown(KeyCode.Space))
                mAnimator.SetTrigger("Attack");
    }
}
