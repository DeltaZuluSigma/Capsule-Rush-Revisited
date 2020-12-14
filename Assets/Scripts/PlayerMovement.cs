using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 2.0f;
    private Vector3 jump;
    private bool isGrounded;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey("a")) { transform.Translate(Vector3.left * Time.deltaTime * speed); }
		if(Input.GetKey("d")) { transform.Translate(Vector3.right * Time.deltaTime * speed); }
		if(Input.GetKeyDown("w") & isGrounded) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
