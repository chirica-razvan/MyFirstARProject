using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    private GameManager gameManagerScript;
    public bool isActive = true;
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (isActive)
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goblin"))
        {
            if (gameManager != null)
            {
                gameManagerScript.targetHit();
            }
        }
    }
}
