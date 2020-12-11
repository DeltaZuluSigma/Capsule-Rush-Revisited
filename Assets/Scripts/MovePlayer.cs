using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float movementSpeed;
    public Rigidbody rb;
    public Vector3 inputVec;
    public bool cubeGround = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec = new Vector3(Input.GetAxisRaw("Horizontal") * 10f, rb.velocity.y, Input.GetAxisRaw("Vertical") * 10f);
        rb.velocity = inputVec;

        if(Input.GetButtonDown("Jump") && cubeGround)
        {
            rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
            cubeGround = false;

        }
       

    }

    private void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.tag == "Ground")
        {
            cubeGround = true;
        }
         

    }



}
