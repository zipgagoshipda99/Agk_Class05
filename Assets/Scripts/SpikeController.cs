using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
   
    //private bool diedbySpike = false;
    public void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        if (enteredCollider.CompareTag("Player"))
        {
            Debug.Log($"{enteredCollider.name} just hit a spike!");
            string diedbySpike = "ouch! you were killed by a spike..";
            HealthManager.healthManager.TakeDamage(diedbySpike);
            
            
        }
        //if (enteredCollider.CompareTag("Player") && diedbySpike == true)
        //{
        //    Debug.Log($"{enteredCollider.name} just hit a spike!");
        //    enteredCollider.GetComponent<HealthManager>().TakeDamage();
        //    UI_Manager.uiManager.ChangeDeathText();
        //}
        
    }
}
