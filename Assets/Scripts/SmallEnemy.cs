using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{


    private int lives;
    private int maxLives;
    private Transform target;
    public float speed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        maxLives = 1;
        lives = maxLives;

    }

    void FixedUpdate()
    {
        Debug.Log(this.transform.childCount);
        if (this.transform.childCount == 0  )//checks if the childs are dead and if they are it will destory the object
        {
            Destroy(this.gameObject);
        }

        if (lives<=0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//if turned into vector 2 only folllows in 2d
    }

    public void dmg()
    {
        lives=lives-50;
    }

    void OnTriggerEnter(Collider col)
    {
        //Vector3 loc = new Vector3(1, 3, 3);
        //Instantiate(SmallEnemyPrefab, loc, Quaternion.identity);
        //Destroy(gameObject);
        //Destroy(this.gameObject);
        
       // Debug.Log(lives);
       
         if (col.GetComponent<Collider>().tag == "Laser")
         {
             this.lives--;
             if (lives == 0)
             {
                Debug.Log("simpo");
                Destroy(this.gameObject);
             }

         }

    }




}
