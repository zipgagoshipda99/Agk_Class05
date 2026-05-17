using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class RespawnManager : MonoBehaviour
{
    //싱글톤 사용
    public static RespawnManager respawnManager;
    private bool isDead = false;

    [Header("오브젝트")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject hudScreen;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI countdownText;
    
    [Header("설정")]
    [SerializeField] private float respawnDelay = 5f;
    

    // Start is called before the first frame update
    private void Awake()//이 스크립트가 부착된 오브젝트가 로드 되었을때 안에 있는 코드를 실행하는 모노비헤이비어 함수
    {
        if(respawnManager == null)
        {
            respawnManager = this;
        }
        else //RespawnManager 스크립트 컴포넌트가 2개 있으면 respawnManager == null이 아니기때문에 그럴때는 그 오브젝트를 없애도록 하는 부분
        {
            Destroy(gameObject);
        }

    }
    public void PlayerDied()

    {
        if (isDead == true)
        {
            return; //벌써 죽어있는 상태면(함수 실행 전) 함수 끝내기
        }
        isDead = true;
        deathScreen.SetActive(true);
        player.SetActive(false);
        hudScreen.SetActive(false);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<CapsuleCollider2D>().enabled = false;
        
        StartCoroutine(RespawnAfterDelay());

    }
    private IEnumerator RespawnAfterDelay()
    {
        for(float i = respawnDelay; i>0; --i)
        {
            countdownText.text = $"Respawning in : {i} seconds";
            yield return new WaitForSeconds(1f);
        }
        player.transform.position = spawnPoint.position;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<CapsuleCollider2D>().enabled = true;
        player.SetActive(true);
        deathScreen.SetActive(false);
        hudScreen.SetActive(true);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<HealthManager>().ResetHearts();
        isDead = false;
        ResetAllMobs();
        
        
        
    }
    private void ResetAllMobs()
    {
        MobController[] EverySingleMob = FindObjectsOfType<MobController>(true); //true 붙인 이유는 active  이 아닌 mob 오브젝트도 찾기 위해서.
        foreach (MobController mob in EverySingleMob)
        {
            mob.ResetMobs();
        }
    }
}
