using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject quitButton;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D enteredCollider)
    {
        if ((enteredCollider.CompareTag("Player")))
        {
            SceneManager.LoadScene("End");
        }
    
        
    }
    public void quitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    public IEnumerator PopupDelay()
    {
        yield return new WaitForSeconds(3.5f);
        quitButton.SetActive(true);
    }
    void Awake()
    {
        StartCoroutine(PopupDelay());
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
