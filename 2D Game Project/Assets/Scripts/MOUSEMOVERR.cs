using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MOUSEMOVERR : MonoBehaviour

{
    //all variables used in the movement
    private float horizontal;
    private float speed = 10f;
    private float jump = 8f;
    private bool isFacingRight = true;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public bool mOUSEMODE = true;
    private AudioSource audioPlayer;

    //all public variables used to share across other codes
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject cheeseScreen;
    [SerializeField] private GameObject cheeseBar;

    //animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //getting components 
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioPlayer = GetComponent<AudioSource>();
        cheeseScreen.SetActive(false);
        cheeseBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //animations for Running and idle
        anim.SetBool("RUN", horizontal != 0);
        anim.SetBool("grounded", isGrounded());

        //if MouseMode is true this allows the player to have normal movement with jumping and an easy to control speed.
        if (mOUSEMODE == true)
        {
            //this.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
            //ancient evil:THIS CODE MAKES YOU PHASE WALLS DO NOT USE, IS FUNNY THOUGH MY THEORY IS TRANSFORM IS FORCEFULLY MOVING IT TO GO INTO OTHER RIGID'S

            //all of this code in the True is obtained from https://www.youtube.com/watch?v=K1xZ-rycYY8&ab_channel=bendux
            //all in Private Void for better response
            horizontal = Input.GetAxisRaw("Horizontal");

            //checks if you are grounded and allowed to jump
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                anim.SetTrigger("JUMP");
                AudioManager.instance.PlayJumpSound();
            }
            //allows you to control your jump's level. The longer you hold the higher, the less, the lower
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            //flips character's sprite to correct direction
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                Flip();
            }
        }
        //second movement when Cheese is picked up, allows you to move exponentially fast with addforce instead of velocity, with no jumping
        //all of this is my code I trailed and error'd
        if (mOUSEMODE == false)
        {
            anim.SetBool("RUN", Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddForce(transform.right * 1500);
                //since flip checks for horizontal I put it here to work locally
                    Vector3 localScale = transform.localScale;
                    localScale.x = 1f;
                    transform.localScale = localScale;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(transform.right * -1500);
                    Vector3 localScale = transform.localScale;
                    localScale.x = -1f;
                    transform.localScale = localScale;
                }

            
            
        }
    }
    //uses a boxcast below player to check if they are on a tile with Ground Layer, from https://www.youtube.com/watch?v=K1xZ-rycYY8&ab_channel=bendux
    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    //flip for Horizontal Input, from https://www.youtube.com/watch?v=K1xZ-rycYY8&ab_channel=bendux
    private void Flip()
    {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
    }

    //horizontal input, calculates velocity and speed, from https://www.youtube.com/watch?v=K1xZ-rycYY8&ab_channel=bendux
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    //triggers cheese mode when touching an object with the tag "cheese"
    //my own code
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Cheese")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("CHEESE MODE ACTIVATED");
            horizontal = 0;
            Destroy(collision.gameObject);
            mOUSEMODE = false;
            sprite.color = Color.yellow;
            cheeseScreen.SetActive(true);
            cheeseBar.SetActive(false);
            
        }
    }
}
