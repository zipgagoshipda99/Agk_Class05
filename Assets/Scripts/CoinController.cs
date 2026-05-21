using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class CoinController: MonoBehaviour
{
    
    private void Awake()
    {
    }
    public int coinAmmount = 0;
    public int coinobtainAmmount = 0;
    public static int totalCoins = 0; //한 값 모든 CoinController가 있는 obj와 공유

    public void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        
        if (enteredCollider.CompareTag("Player") && gameObject.name =="Coin")
        {
            gameObject.SetActive(false);
            coinAmmount +=5;
            coinobtainAmmount = 5;
            UI_Manager.ui_Manager.coinObtain(this);
        }
        else if(enteredCollider.CompareTag("Player") && gameObject.name == "Chest")
        {
            gameObject.SetActive(false);
            coinAmmount +=10;
            coinobtainAmmount = 10;
            
            UI_Manager.ui_Manager.coinObtain(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
