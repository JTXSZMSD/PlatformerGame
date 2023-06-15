using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 100f)] public float jumpForce = 8f;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffSetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;
    
    public Animator anim;

    private RaycastHit2D hit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down); // пускаем рейкаст из центра объекта вниз
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight) 
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 3f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();

        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);
        //if (hit.collider != null) // если попали в какое-нибудь препятствие,
        //{
        //    transform.up = hit.normal; // то задаём объекту направление «вверх» такое же, как нормаль к поверхности препятствия в точке попадания рейкаста
        //}
        //else
        //{
        //    transform.up = Vector3.up; // иначе пусть верх у объекта будет сверху.
        //}
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffSetY), checkGroundRadius);

        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else 
        { 
            isGrounded= false;
        }
    }
}
