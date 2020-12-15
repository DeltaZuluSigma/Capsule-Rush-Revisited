
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShooter : MonoBehaviour
{
    private Transform target;
    private float speed = 4.0f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float power = 5000.0f;
    private float radius = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//gets the target
        Destroy(gameObject, 5f);//timer

    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    


    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "Enemy" || col.GetComponent<Collider>().tag == "Head" || col.GetComponent<Collider>().tag == "EnemyLaser" || col.GetComponent<Collider>().tag == "Obstacle" || col.GetComponent<Collider>().tag == "Spawner")
        {

        }
        else
        {
            if (col.GetComponent<Collider>().tag == "Player")
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if (rb != null && rb.tag == "Player")
                    {
                        rb.AddExplosionForce(power, transform.position, radius);
                    }
                }
                //nearbyObject.GetComponent<>;
            }
            Destroy(this.gameObject);
        }

    }
}
