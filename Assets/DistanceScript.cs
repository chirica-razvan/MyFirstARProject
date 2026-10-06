using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DistanceScript : MonoBehaviour
{
    private Character character;
    private List<DistanceScript> otherDistanceScripts = new List<DistanceScript>();
    void Start()
    {
        character = GetComponentInChildren<Character>();

        if (character == null)
        {
            Debug.LogWarning("Nu am gasit script-ul character");
        }

        DistanceScript[] allScripts = FindObjectsByType<DistanceScript>(FindObjectsSortMode.None);

        foreach (DistanceScript script in allScripts) {
            if (script != this)
            {
                otherDistanceScripts.Add(script);
            }
            Debug.Log($"Obiectul [{gameObject.name}] a gasit {otherDistanceScripts.Count} alte obiecte în scena.");
        }
    }

    float distance;
    private Transform targetObject;
    // Update is called once per frame
    void Update()
    {
        float distanceToCurrentTarget = Mathf.Infinity;
        Transform currentTarget = null;
        foreach (DistanceScript script in otherDistanceScripts)
        {
            if (script != null)
            {
                targetObject = script.transform;
                distance = Vector3.Distance(transform.position, targetObject.position);
                if(distance < 0.22 && distance < distanceToCurrentTarget)
                {
                    currentTarget = targetObject;
                    distanceToCurrentTarget = distance;
                    //Debug.Log($"Obiectul [{gameObject.name}] este la o distanta de {distance} de obiectul [{targetObject.gameObject.name}]");
                }
            }
        }

        if (currentTarget != null)
        {
            //float distance = Vector3.Distance(transform.position, targetObject.position);
            //Debug.Log("Distance to target object: " + distance);

            if (distanceToCurrentTarget < 0.22)
            {
                Debug.Log("ATACA BAI!!!!");
                Debug.Log($"Obiectul [{gameObject.name}] este la o distanta de {distance} de obiectul [{targetObject.gameObject.name}]");
                //character.MakeAttack();
            }
        }


    }
}
