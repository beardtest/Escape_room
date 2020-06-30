using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D coll;
    
    //data collection within unity
    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask ground;

    //variable init
    private float jumpForce = 10;
    private Vector2 ClickRange = new Vector2(3,3);
    private bool CanMouseFire = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MouseCapture();
        Movement();
        if(Input.GetButton("Fire1")){
            MouseInteraction();
        }

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

    private void MouseCapture(){
        //getting mouse position on screen as well as players position
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Pposition = new Vector2(rb.position.x, rb.position.y);

        //variable to work out mouse distance from player
        Vector2 mouse2player = mouse - Pposition;

        //form here the class simply sets the variable true or false based on how close the mouse is to the player
        if (mouse2player.x > ClickRange.x || mouse2player.x < -ClickRange.x){
            CanMouseFire = false;
        }

        else if (mouse2player.y > ClickRange.y || mouse2player.y < -ClickRange.y){
            CanMouseFire = false;
        }

        else{
            CanMouseFire = true;
        }
    }

    private void MouseInteraction(){
        if(Input.GetButton("Fire1") && CanMouseFire){
            Debug.Log("firin' ma lazer");
        }
    }
}
