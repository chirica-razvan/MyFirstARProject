using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Collider goalCollider;
    [SerializeField] public GameObject targetBall;
    [SerializeField] public GameObject character;
    private CharacterScript characterScript;
    private BallScript ballScript;

    void Start()
    {
        characterScript = character.GetComponent<CharacterScript>();
        ballScript = targetBall.GetComponent<BallScript>();
        spawnTargetBall();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnTargetBall();
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            destroyTarget();
        }

    }
    void destroyTarget()
    {

        if (targetBall != null)
        {
            ballScript.isActive = false;
            targetBall.transform.position = new Vector3(-1, -1, -1);
        }
    }
    void spawnTargetBall()
    {
        if (targetBall != null && goalCollider != null)
        {
            ballScript.isActive = true;

            Bounds bounds = goalCollider.bounds;

            Vector3 randomPoint = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );

            targetBall.transform.position = randomPoint;
        }
    }
   
    public void targetHit()
    {
        destroyTarget();
        // UIScript.updateScore();

        StartCoroutine(waitThenResetScene());
    }

    public void targetMissed()
    {
        // UIScript.updateScore();
        characterScript.resetCharacterPosition();
    }

    void resetScene()
    {
        //characterScript.resetCharacter();
        spawnTargetBall();
    }

    IEnumerator waitThenResetScene()
    {
       yield return new WaitForSeconds(3f);
       resetScene();
    }

}
