using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour

{
    public static UI_Manager ui_Manager;

    public void Awake()
    {
        if(ui_Manager == null)
        {
            ui_Manager = this;
        }
    }
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private TextMeshProUGUI deathText;
    [SerializeField] private TextMeshProUGUI coinObtainText;
    [SerializeField] private TextMeshProUGUI coinAmountText;
    
    public static GameObject quitButton;
    //[SerializeField] private List<string>  d_textlist = new List<string>();
    public void StartGame()
    {
        Player.SetActive(true);
        StartMenu.SetActive(false);
    }
    public void EnterInfo()
    {
        infoPanel.SetActive(true);
    }
    public void ExitInfo()
    {
        infoPanel.SetActive(false);
    }
    public void EnterCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void coinObtain(CoinController coinController)
    {
       
        
      
        coinObtainText.text = $"코인 +{coinController.coinobtainAmmount} 획득!";
        CoinController.totalCoins += coinController.coinobtainAmmount;
        coinAmountText.text = $"코인: +{CoinController.totalCoins}";
        StartCoroutine(textDelay());
        
        //coinObtainText.text = ""; <- 이러면 안됨 버그 함수 안에서 기달리는거지 함수를 불렀다고 기달리는 건 아님 ㅇㅇ 
        //coinAmountText.text = "";
    }

    private IEnumerator textDelay()
    {
        yield return new WaitForSeconds(3f);
        coinObtainText.text = "";
    }

    // public void ChangeDeathText()
    // {
    //     int i = Random.Range(0, d_textlist.Count);
    //     deathText.text = d_textlist[i]; 
    // }
    private void Start()
    {
        Player.SetActive(false);
    }
}
