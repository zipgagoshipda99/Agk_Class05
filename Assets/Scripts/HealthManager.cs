using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using Microsoft.Unity.VisualStudio.Editor; 다른 image type 추가해서 주석 처리
public class HealthManager : MonoBehaviour
{
    public static HealthManager healthManager;
    private int maxHearts = 3;
    [Header("하트 설정")]
    [SerializeField]private Image[] heartImages;

    [Header("하트 스프라이트")]

    [SerializeField]private Sprite fullHeart;
    [SerializeField]private Sprite emptyHeart;
    
    [Header("무적 설정")] //스파이크 닿은 후 무적 몇초 동안 할건지

    [SerializeField]private float invincibleDuration = 1.5f;
    private bool isInvincible = false;
    private int currentHearts;

    private void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartUI();
    }
    private void UpdateHeartUI()
    {
        for(int i = 0; i < heartImages.Length; i++)
        {
            if(i < currentHearts)
            {
                heartImages[i].sprite = fullHeart;
            }
            else if(currentHearts <= i)
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }
    private IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleDuration);
        isInvincible = false;
    }
    public void InstantDeath()
    {
        currentHearts = 0;
        UpdateHeartUI();
        RespawnManager.respawnManager.PlayerDied();
        
    }

    public void ResetHearts()
    {
        currentHearts = maxHearts;
        UpdateHeartUI();
    }

    public void TakeDamage()
    {
        if (isInvincible)
        {
            return; //isInvicible가 true면 메소드를 끝내는 부분
        }
        currentHearts -= 1;
        UpdateHeartUI();

        if (currentHearts <= 0)
        {
            RespawnManager.respawnManager.PlayerDied();
            return; // playerdied메소드를 실행하고 이 메소드를 끝내는 부분. 만약 위에 if invincible 조건이 true면 2번째인 이 if조건은 실행 ㄴㄴ.

        }
        StartCoroutine(Invincibility());
    }

}
