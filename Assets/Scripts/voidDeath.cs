using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class voidDeath : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        Debug.Log("Entered: " + enteredCollider.name);
        if (enteredCollider.CompareTag("Player"))
        {
            Debug.Log("Player entered death zone!");
            HealthManager.healthManager.InstantDeath();            
        }
        if (enteredCollider.CompareTag("Mob"))
        {
            Debug.Log($"{enteredCollider.name} entered death zone!");
            enteredCollider.gameObject.SetActive(false);
        }
    }
}
