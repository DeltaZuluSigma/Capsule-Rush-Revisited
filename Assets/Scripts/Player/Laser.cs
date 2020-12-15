using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Material material;
    public int killShots;
    public float timer;

    void Start()
    {
        this.GetComponent<Renderer>().material = material;
        killShots = 0;
        timer = 5.0f;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(this.gameObject);
            timer = 5.0f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            killShots++;
            /*if (col.gameObject.GetComponent<LargeEnemy>())
            {
                int h = col.gameObject.GetComponent<LargeEnemy>().lives;
                if (h <= 1)
                    killShots++;
            }

            if (col.gameObject.GetComponent<MedEnemy>())
            {
                int h = col.gameObject.GetComponent<MedEnemy>().lives;
                if (h <= 1)
                    killShots++;
            }

            if (col.gameObject.GetComponent<SmallEnemy>())
            {
                int h = col.gameObject.GetComponent<SmallEnemy>().lives;
                if (h <= 1)
                    killShots++;
            }

            if (col.gameObject.GetComponent<BounceShooter>())
            {
                int h = col.gameObject.GetComponent<BounceShooter>().lives;
                if (h <= 1)
                    killShots++;
            }

            if (col.gameObject.GetComponent<TeleExplosion>())
            {
                int h = col.gameObject.GetComponent<TeleExplosion>().lives;
                if (h <= 1)
                    killShots++;
            }*/

        }

        if (col.gameObject.layer == LayerMask.NameToLayer("obstacle") || col.gameObject.layer == LayerMask.NameToLayer("ground"))
            Destroy(this.gameObject);
    }


}
