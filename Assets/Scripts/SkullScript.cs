using UnityEditor.Rendering;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
     [SerializeField] GameObject character;
    private float timeSinceDeath = 0;
    bool isActive = false;
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            isActive = true;
            this.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
            timeSinceDeath += Time.deltaTime;

            if(timeSinceDeath >= 3f)
            {
                this.gameObject.SetActive(false);
                character.SetActive(true);
                isActive = false;
                timeSinceDeath = 0;
            }
        }

    }

    private void Awake()
    {
        timeSinceDeath = 0;
    }
}
