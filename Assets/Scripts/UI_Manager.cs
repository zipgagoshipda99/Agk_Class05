using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour

{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private TextMeshProUGUI deathText;
    [SerializeField] private List<string>  d_textlist = new List<string>();

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

    public void ChangeDeathText()
    {
        int i = Random.Range(0, d_textlist.Count);
        deathText.text = d_textlist[i]; 
    }
    private void Start()
    {
        Player.SetActive(false);
    }
}
