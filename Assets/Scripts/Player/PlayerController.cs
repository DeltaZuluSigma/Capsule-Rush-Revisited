using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;         // determines the height of jump
    private bool isGrounded;        // if player is touching the ground ? true : false
    private bool canJump;
    private bool doubleJump;     // determines if player has double jumped

    public float walkSpeed;                 // player walk speed
    public float runSpeed;                  // player run speed
    private bool isFacingRight;     // if player is facing right ? true : false (left)

   
    public Rigidbody rigidBody;    // reference to players RigidBody
    private Vector3 pVelocity = Vector3.zero; // for movement damping
    private float movementSmoothing = .05f;  // How much to smooth out the movement

    private float horizontalMove;

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody>();

        horizontalMove = 0.0f;
        doubleJump = false;
    }

    void Update()
    {
        runCheck();
        jumpCheck();
    }

    void FixedUpdate()
    {
        // uses controller to move left and right and jump
        move(horizontalMove * Time.fixedDeltaTime, canJump);

        canJump = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            isGrounded = false;
        }
    }

    public void move(float move, bool j) {

        // allows player to jump
        if (isGrounded && j)
        {
            jump();
            doubleJump = true;
        }
        else if (doubleJump && !isGrounded && j)
        {
            jump();
            doubleJump = false;
        }
       
      
        // to move character
        Vector3 targetVelocity = new Vector3(move * 10f, rigidBody.velocity.y, 0.0f);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref pVelocity, movementSmoothing);


        // controls which way the player faces
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }

    private void runCheck()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        else horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
    }

    // button check functions
    void jumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
    }

    private void Flip()
    {
        // switch direction the player is labelled as facing
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void jump()
    {
        //  allows player to jump by adding verticle force to the rigibody
        rigidBody.AddForce(new Vector3(0f, jumpForce, 0f));
        isGrounded = false;
    }

    
}
