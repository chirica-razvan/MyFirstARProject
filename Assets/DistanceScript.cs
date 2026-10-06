using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform targetObject;
    private Character character;
    void Start()
    {
        character = GetComponentInChildren<Character>();

        if (character == null)
        {
            Debug.LogWarning("Nu am gasit script-ul character");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(targetObject != null)
        {
            float distance = Vector3.Distance(transform.position, targetObject.position);
            //Debug.Log("Distance to target object: " + distance);

            if (distance < 0.22)
            {
                Debug.Log("ATACA BAI!!!!");
                character.MakeAttack();
            }
        }


    }
}
