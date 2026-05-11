using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;

    

    public void EnterInfo()
    {
        infoPanel.SetActive(true);
    }
    public void ExitInfo()
    {
        infoPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
