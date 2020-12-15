using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{


    private Transform target;
    private float speed = 2.0f;
    private Rigidbody rb;
    private Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//gets the target
        moveDirection = ((target.transform.position - this.transform.position).normalized * speed);
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 0.5f);//timer

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "Enemy" || col.GetComponent<Collider>().tag == "Head" || col.GetComponent<Collider>().tag == "EnemyLaser" || col.GetComponent<Collider>().tag == "Obstacle" || col.GetComponent<Collider>().tag == "Spawner")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
