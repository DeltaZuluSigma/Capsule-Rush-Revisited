using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedEnemy : MonoBehaviour
{
    public GameObject EnemyLaser;
    private int lives;
    private int maxLives;
    private Transform target;
    private float coolDown = 1f;//this is in seconds can be switched for later use if some other itme is prefered 
    private float coolDownTimer;
    int maxNumberOfComponents = 2;

    // Start is called before the first frame update
    void Start()
    {
        
        maxLives = 5;
        lives = maxLives;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log (this.transform.childCount);
        //this.transform.childCount prints the current number of children of the object not including the parent, it will be 1 when it is active and 0 when not since the cylinder is a child of the sphere


        if (this.transform.childCount == 0)//checks if the childs are dead and if they are it will destory the object
        {
            Destroy(this.gameObject);
        }

        if (lives <= 0)//if lives are less than or equal to zero it destroys the object
        {
            Destroy(this.gameObject);
        }
        else//if the enemy still has lives it goes into this scipt
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
                Instantiate(EnemyLaser, this.transform.position, Quaternion.identity);//makes the lasers if the cooldown is done

                GameObject l = Instantiate(EnemyLaser) as GameObject;
                //l.transform.position = this.transform.position;
                coolDownTimer = coolDown;//resets cooldown

            }
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.GetComponent<Collider>().tag == "Laser")
        {
            this.lives--;
           
        }

    }

    public void dmg()
    {
        lives = lives - 50;
    }
}
