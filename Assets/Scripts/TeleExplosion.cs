using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleExplosion : MonoBehaviour
{

   
    private int lives;
    private int maxLives;
    private Transform target;
    private float coolDown = 10;//this is in seconds can be switched for later use if some other itme is prefered 
    private float coolDownTimer;
    private float speed;
    private int tele;
    public Transform explosion;

    // Start is called before the first frame update
    void Start()
    {
        maxLives = 2;
        lives = maxLives;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        coolDownTimer = 5;
        speed = 0.5f;
        tele = 1;
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
            if (transform.position.x >= (target.position.x - 15) && transform.position.x <= (target.position.x + 15))
            {
                if (transform.position.x >= (target.position.x - 5) && transform.position.x <= (target.position.x + 5))
                {
                    StartCoroutine(explosionDelay());
                    tele = 0;
                }

                    if (coolDownTimer > 0)
                {
                    coolDownTimer -= Time.deltaTime;
                }
                if (coolDownTimer < 0)
                {
                    coolDownTimer = 0;
                }

                if (coolDownTimer == 0 && tele == 1)
                {
                    transform.position = new Vector3(target.position.x + 2, target.position.y - 0.57f, target.position.z);//x and z can be changed accordingly
                                                                                                                          //Debug.Log(coolDownTimer);
                    coolDownTimer = coolDown;
                    //Debug.Log(coolDownTimer);
                }
                if (tele == 1)
                {

                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }

                if (transform.position.y == target.position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y -0.57f, transform.position.z);
                }
            }

        }
    }

    

    void OnTriggerEnter(Collider col)
    {


         //Debug.Log(lives);

        if (col.GetComponent<Collider>().tag == "Laser" && this.tele == 1)
        {
            //Debug.Log("a");
            this.lives--;
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.red;
            }
            StartCoroutine(delay());

        }

    }

    IEnumerator delay()
    {

        yield return new WaitForSeconds(0.5f);

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = new Color(2f / 255f, 165f/255f, 243f / 255f);
        }
    }

    IEnumerator explosionDelay()
    {
        
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            //Color oldColor = r.material.color;
            r.material.color = new Color(2f, 165f, 243f, 100f);
            //Debug.Log(r.material.color.g);
        }
        
        yield return new WaitForSeconds(5f);
        //Debug.Log("b");
        GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
        Destroy(exploder, 2.0f);
        Destroy(this.gameObject);
        //set some kind of call to player object to make player know of explosion

    }

}
