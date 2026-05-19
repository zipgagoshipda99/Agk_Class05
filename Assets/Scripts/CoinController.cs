using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController: MonoBehaviour
{
    public static CoinController coinController;
    private void Awake()
    {
        if (coinController == null)
        {
            coinController = this;
        }
    }
    public int coinAmmount = 0;
    public int coinobtainAmmount = 0;
    public void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        
        if (enteredCollider.CompareTag("Player") && gameObject.name =="Coin")
        {
            gameObject.SetActive(false);
            coinAmmount +=5;
            coinobtainAmmount = 5;
            UI_Manager.ui_Manager.coinObtain();
        }
        else if(enteredCollider.CompareTag("Player") && gameObject.name == "Chest")
        {
            gameObject.SetActive(false);
            coinAmmount +=10;
            coinobtainAmmount = 10;
            UI_Manager.ui_Manager.coinObtain();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
