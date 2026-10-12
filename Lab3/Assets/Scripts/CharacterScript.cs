using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    private GameManager gameManagerScript;
    Vector3 originalPosition;
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        originalPosition = transform.position;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            if (gameManager != null)
            {
                gameManagerScript.targetMissed();
            }
        }
    }

    public void resetCharacterPosition()
    {
        transform.position = originalPosition;
    }
}
