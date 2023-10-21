using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOUSEMOVERR : MonoBehaviour
{

    private float speed = 10f;
    private float jump = 5f;
    private bool isFacingRight = true;
    private BoxCollider2D coll;
    bool mOUSEMODE = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {



        if (mOUSEMODE == true)
        {


            //this.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
            //THIS CODE MAKES YOU PHASE WALLS DO NOT USE, IS FUNNY THOUGH MY THEORY IS TRANSFORM IS FORCEFULLY MOVING IT TO GO INTO OTHER RIGID'S

            horizontal = Input.GetAxisRaw("Horizontal");


            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();
        }

        if (mOUSEMODE == false)
        {
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(transform.right * 50);
                    Debug.Log("addforce");

                }

                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(transform.right * -50);
                    Debug.Log("addforce");

                }
            }

            Flip();




        }









    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CHEESE MODE UNACTIVE");
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Cheese")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("CHEESE MODE ACTIVATED");
            mOUSEMODE = false;
            Destroy(collision.gameObject);

        }
    }
}
