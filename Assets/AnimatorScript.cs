using UnityEngine;



public class AnimatorScript : MonoBehaviour
{

    private Animator mAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                mAnimator.SetTrigger("Crunches");
            }
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    mAnimator.SetBool("isWalking", true);
            //}
            
        }
        
    }
}
