using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : MonoBehaviour
{

    public GameObject tongue;
    public int lives;
    private int maxLives;
    private Transform target;
    private float coolDown = 5;//this is in seconds can be switched for later use if some other itme is prefered 
    private float coolDownTimer;
    private float speed;
    private int teleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxLives = 1;
        lives = maxLives;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        coolDownTimer = 10;
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
            if (transform.position.x >= (target.position.x - 15) && transform.position.x <= (target.position.x + 15) ) {

                

                if (transform.position.x >= (target.position.x - 8) && transform.position.x <= (target.position.x + 8)) {
                    if (coolDownTimer >= 0.75f)
                    {
                        Vector3 temp = new Vector3(this.transform.position.x-2, this.transform.position.y, this.transform.position.z);
                        Instantiate(tongue, temp, Quaternion.identity);
                    }
                }

                if (coolDownTimer > 0)
                {
                    coolDownTimer -= Time.deltaTime;
                }
                if (coolDownTimer < 0)
                {
                    coolDownTimer = 0;
                }

                if (coolDownTimer == 0 && teleCount < 3)
                {
                    transform.position = new Vector3(target.position.x + 2, target.position.y + 1.47f, target.position.z);//x and z can be changed accordingly
                    teleCount++;                                                                                                //Debug.Log(coolDownTimer);
                    coolDownTimer = coolDown;
                }

                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                if (transform.position.y == target.position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1.47f, transform.position.z);
                }
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
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.red;
            }
            this.lives--;
            StartCoroutine(delay());

        }

    }

    IEnumerator delay()
    {

        yield return new WaitForSeconds(0.5f);

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = new Color(25f / 255f, 0, 221f / 255f);
        }
        //Debug.Log("c");
    }

}
