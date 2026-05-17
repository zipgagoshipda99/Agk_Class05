using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
//  the script will only run if the object has a rigid body 2d componet
public class PlayerController: MonoBehaviour
{
    [Header("이동")]
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpStrength = 8f;
    
    [Header("바닥 체크")]
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundcheckRadius = 0.05f;
    [SerializeField]private LayerMask groundLayer;
    
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRender;

    private float moveInput;
    private bool jumpRequested;
    private bool isGrounded;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        //가로 입력 읽는거 (-1, 0  or 1)
        moveInput = Input.GetAxisRaw("Horizontal");
        //Axis horizontal is default keybinds set to A,D or leftArrow, rightArrow

        //바닥 감지 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundcheckRadius,groundLayer);

        //jumpRequested를 true로 만들려면 W, space, arrowUp 중에서 눌르거나 바닥에 있을때만 (isGrounded) 그리고 절대값이 0.01과 같거나 작을때만 true로 만들수 있도록 하는 if문
        // c# &&가 먼저 실행되므로 || 부분을 괄호로 묶어줌
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded && Mathf.Abs(rb.velocity.y) <= 0.01f)

        {
            jumpRequested = true;
            Debug.Log("jump has been requested.");
        }
        //
        if (moveInput > 0)
        {
            spriteRender.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRender.flipX = true;
        }
        animator.SetBool("isRunning", Mathf.Abs(moveInput) > 0.01f);
        //SetBool(bool 매개변수, 조건문) 
        //조건문이 true면 bool인 매개변수를 true로 만들고 반대로 조건문이 false면 bool 매개변수를 false로 만듬 ㅇㅇ
        //If Mathf.Abs(moveInput)  0.01f is true -> isRunning becomes true -> Animator switches to run animation.
        animator.SetBool("isGrounded", isGrounded);


    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (jumpRequested)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);

            jumpRequested = false;

        }
    }
}
