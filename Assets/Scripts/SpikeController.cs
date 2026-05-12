using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
   
    //private bool diedbySpike = false;

    private void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        if (enteredCollider.CompareTag("Player"))
        {
            Debug.Log($"{enteredCollider.name} just hit a spike!");
            enteredCollider.GetComponent<HealthManager>().TakeDamage();
        }
        //if (enteredCollider.CompareTag("Player") && diedbySpike == true)
        //{
        //    Debug.Log($"{enteredCollider.name} just hit a spike!");
        //    enteredCollider.GetComponent<HealthManager>().TakeDamage();
        //    UI_Manager.uiManager.ChangeDeathText();
        //}
        
    }
}
