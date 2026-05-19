using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MobController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRender;
    private bool moveRight = true; //true 면 오른쪽으로 이동 false면 왼쪽
    private bool isWaiting = false;
    private Vector3 startPosition; 
    [Header("순찰 설정")]
    [SerializeField]private float moveSpeed = 3f;
    [SerializeField]private Transform PatrolPointRight;
    [SerializeField]private Transform PatrolPointLeft;
    

    [Header("참조한 것")]
    [SerializeField]private GameObject playerObj;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
    }
    public void ResetMobs()
    {
        transform.position = startPosition; //포지션 리셋
        moveRight = true; //어느 방향인지 리셋 (처음으로)
        isWaiting = false;
        rb.velocity = new Vector2(0,0);
        rb.angularVelocity = 0f;
        transform.rotation = Quaternion.identity;
        //Quaternion.identity = (x:0, y:0, z:0, w:1) <- basically setting roation to 0,0,0,0 so logically no rotation.
        
        //xyz = which axis to rotate around..
        //w= how much to rotate, w=1 no rotation
        
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (isWaiting)
        {
            return;
        }
        Patrol();
    }
    private void Patrol()
    {
        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                                    //(양수 면 오른쪽으로 ,중력)         
            spriteRender.flipX = true;
            if(transform.position.x >= PatrolPointRight.position.x)
            {
                StartCoroutine(WaitThenTurn());
                return;
            }
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                                     //(음수 면 왼쪽 방향 ,중력)
            spriteRender.flipX = false;

            if(transform.position.x <= PatrolPointLeft.position.x)
            {  
                StartCoroutine(WaitThenTurn());
                return;
            }
        }
        animator.SetBool("mob_isRunning", true);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D enteredCollider)

    {
        if (enteredCollider.gameObject == playerObj)
        {
            Debug.Log($"{enteredCollider} just hit a mob!");
            string diedbyMob = "you just got UNALIVED by a mob. DO better XD";
            HealthManager.healthManager.TakeDamage(diedbyMob);
        }
    }
    private IEnumerator WaitThenTurn()
    {
        isWaiting = true;
        rb.velocity = new Vector2(0,0); //모든 움직임 멈춤
        animator.SetBool("mob_isRunning", false);
        moveRight = !moveRight;

        //if (moveRight == true) moveRight = false;
        //else if (moveRight ==false) moveRight = true;

        //spriteRender.flipX = moveRight; 3초 기달리기 전에 반대방향으로 뒤집기(근데 후가 더 편한듯 그래서 걍 주석 처리)
        yield return new WaitForSeconds(3);
        isWaiting = false;
    }

}
