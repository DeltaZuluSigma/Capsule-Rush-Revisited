using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePowerUp : MonoBehaviour
{
    public GameObject LazerGun;
    public GameObject SpeedBoost;
    public GameObject Teleport;
    public GameObject Invincibility;
    public GameObject OneUp;
    private int i = 0;

    //spawner location randomise which enemy is spawned and where

    void FixedUpdate()
    {
        if (i == 0)
        {
            int rand = RandNum.GetRandomNumber(0, 99);

            if (rand < 20)
            {
                Instantiate(LazerGun, transform.position, Quaternion.identity);
            }
            else if (rand > 20 && rand < 40)
            {
                Instantiate(SpeedBoost, transform.position, Quaternion.identity);
            }
            else if (rand > 40 && rand < 60)
            {
                Instantiate(Teleport, transform.position, Quaternion.identity);
            }
            else if (rand > 60 && rand < 80)
            {
                Instantiate(Invincibility, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(OneUp, transform.position, Quaternion.identity);
            }

            i++;
        }

    }
}
