using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D enteredCollider)
    {
         Debug.Log("Entered: " + enteredCollider.name);
        if (enteredCollider.CompareTag("Player"))
        {
            Debug.Log("Player entered death zone!");
            enteredCollider.GetComponent<HealthManager>().InstantDeath();
            //HealthManager.healthManager.InstantDeath();
        }
    }
}
