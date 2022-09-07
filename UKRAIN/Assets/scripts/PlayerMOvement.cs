using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOvement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Joystick Joystick;
    private bool faceright= true;
   
    private float dirx = 0f;
    public bool ISJumping;
    
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource JumpSound;
    
    private BoxCollider2D coll;
   

    private void Start()

    {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
     
        coll = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if(Joystick.Horizontal >= .2f)
        {
            dirx = MoveSpeed;
        }else if(Joystick.Horizontal <= -.2f)
        {
            dirx = -MoveSpeed;

        }
        else
        {
            dirx =0f;
        }
        rb.velocity = new Vector2(dirx * MoveSpeed, rb.velocity.y);
        float diry =Joystick.Vertical;

       
        if (diry >= .5f && ISJumping==false)
        {
            Jump();
            JumpSound.Play();
        }
        
        
        if(dirx == 0f)
        {
            anim.SetBool("running",false);
        }
        else
        {
            anim.SetBool("running", true);
        }
        if(faceright== false && Joystick.Horizontal > 0)
        {
            Flip();
        }
        if (faceright == true && Joystick.Horizontal < 0)
        {
            Flip();
        }
    }


    void Jump()
    {
        rb.velocity = Vector2.up * JumpForce;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            ISJumping = false;
            anim.SetBool("jumping",false );
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            ISJumping = true;
            anim.SetBool("jumping", true);
        }
    }
    void Flip()
    {
        if (PauseMenu.gameIsPaused == false) {
            faceright = !faceright;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        
    }
    
}
