using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        if (enteredCollider.CompareTag("Player"))
        {
            Debug.Log("Player just hit a spike!");
            enteredCollider.GetComponent<HealthManager>().TakeDamage();
        }
        
    }
}
