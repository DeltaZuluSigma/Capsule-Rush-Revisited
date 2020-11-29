using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : MonoBehaviour
{

    private int lives;
    private int maxLives;
    private Transform target;
    private float coolDown = 5;//this is in seconds can be switched for later use if some other itme is prefered 
    private float coolDownTimer;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        maxLives = 10;
        lives = maxLives;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        coolDownTimer = 2;
        speed = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (this.transform.childCount == 0)//checks if the childs are dead and if they are it will destory the object
        {
            Destroy(this.gameObject);
        }

        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }
            if (coolDownTimer < 0)
            {
                coolDownTimer = 0;
            }

            if (coolDownTimer == 0)
            {
                transform.position = new Vector3(target.position.x + 2, target.position.y + 1.47f, target.position.z);//x and z can be changed accordingly
                                                                                                                      //Debug.Log(coolDownTimer);
                coolDownTimer = coolDown;
                //Debug.Log(coolDownTimer);

            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (transform.position.y == target.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1.47f, transform.position.z);
            }
        }
    }


    public void dmg()
    {
        lives = lives - 50;
    }

    void OnTriggerEnter(Collider col)
    {
        

        // Debug.Log(lives);

        if (col.GetComponent<Collider>().tag == "Laser")
        {
            this.lives--;
        }
        if (col.GetComponent<Collider>().tag == "Ground")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.47f, transform.position.z);


        }
        if (col.GetComponent<Collider>().tag == "Player" && this.GetComponent<Collider>().tag == "Head")
        {
            Debug.Log("yes");
            Destroy(this.gameObject);
            lives=0;

        }

    }


}
