using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOUSEMOVER2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
}
