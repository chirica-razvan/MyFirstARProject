using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    private GameManager gameManagerScript;
    public bool isActive = true;
    [SerializeField] private ParticleSystem particles;
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
                Instantiate(particles, transform.position, Quaternion.identity);
                gameManagerScript.targetHit();
            }
        }
        
    }
}
