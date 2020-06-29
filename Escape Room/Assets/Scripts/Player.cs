using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D coll;

    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask ground;

    private float jumpForce = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        var deadZone = 0.25;
        var HMovement = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Jump") > 0.1 && coll.IsTouchingLayers(ground))
        {
            Jump();
        }

        else if (HMovement < -deadZone)
        {

            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //transform.localScale = new Vector2(-1, 1);


        }

        else if (HMovement > deadZone)
        {

            rb.velocity = new Vector2(speed, rb.velocity.y);
            //transform.localScale = new Vector2(1, 1);

        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
