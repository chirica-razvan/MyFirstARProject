using Unity.VisualScripting;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    private GameManager gameManagerScript;
    Vector3 originalPosition;
    private Rigidbody rb;
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        originalPosition = transform.position;
        
        rb = gameObject.GetComponent<Rigidbody>();
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
        rb.linearVelocity = Vector3.zero;
    }
}
