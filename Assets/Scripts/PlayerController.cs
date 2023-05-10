using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float playerSpeed = 1f;
    public float jumpForce = 10f;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    public Animator anim;

    
    float horizontal;

    
    void Start()
    {
       
        
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        anim = GetComponent<Animator>();
        
    }

    
    void Update()

        {
            horizontal = Input.GetAxis("Horizontal"); 

            if(horizontal < 0)
            {
                
                transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.SetBool("IsRunning", true);
            }
            else if(horizontal > 0)
            {
                
                transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }

            if(Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }

        }    
        
    

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }
    
}