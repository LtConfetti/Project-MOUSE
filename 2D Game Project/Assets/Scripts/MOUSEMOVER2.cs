using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOUSEMOVER2 : MonoBehaviour

    
{
    private float horizontal;
    private float speed = 10f;
    private float jump = 8f;
    private bool isFacingRight = true;
    private BoxCollider2D coll;
    public bool mOUSEMODE = true;

    [SerializeField] private MOUSEMOVERR mouseMode;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("RUN", horizontal != 0);
        anim.SetBool("grounded", isGrounded());

        if (mOUSEMODE == true)
        {
            //this.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
            //ancient evil:THIS CODE MAKES YOU PHASE WALLS DO NOT USE, IS FUNNY THOUGH MY THEORY IS TRANSFORM IS FORCEFULLY MOVING IT TO GO INTO OTHER RIGID'S

            horizontal = Input.GetAxisRaw("Horizontal");


            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                anim.SetTrigger("JUMP");
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                //anim.SetTrigger("JUMP");
            }

            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                Flip();
            }
        }

    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cheese")
        {
            mOUSEMODE = false;
            Destroy(collision.gameObject);
        }
    }
}