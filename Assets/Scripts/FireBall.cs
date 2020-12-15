using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{


    private Transform target;
    private float speed = 10.0f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 lastVelocity;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//gets the target
        moveDirection = ((target.transform.position - this.transform.position).normalized * speed);
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 5);//timer

    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy"|| col.gameObject.tag == "Head" || col.gameObject.tag == "EnemyLaser" || col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Spawner"|| col.gameObject.tag == "Ground"|| col.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Spawner" || col.gameObject.tag == "Ground"|| col.gameObject.layer == LayerMask.NameToLayer("ground"))
            {
                ContactPoint cp = col.contacts[0];
                //rb.velocity = Vector3.Reflect(lastVelocity, cp.normal);
            }
        }
        
        else
        {
            Destroy(this.gameObject);
        }

    }
}
