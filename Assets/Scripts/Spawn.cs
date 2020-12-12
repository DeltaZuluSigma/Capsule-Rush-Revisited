using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SmallEnemyPrefab;
    public GameObject MedEnemyPrefab;
    public GameObject LargeEnemyPrefab;
    public GameObject TeleExplosion;
    public GameObject shooter;
    private int i = 0;//this is in seconds can be switched for later use if some other itme is prefered 
    private float coolDownTimer=0;

    //spawner location randomise which enemy is spawned and where

    void FixedUpdate()
    {
        if (i == 0)
        {

                System.Random rnd = new System.Random();
                int rand = rnd.Next(99);

                if (rand < 20)
                {
                    Instantiate(SmallEnemyPrefab, transform.position, Quaternion.identity);
                }
                else if (rand > 20 && rand < 40)
                {
                    Instantiate(MedEnemyPrefab, transform.position, Quaternion.identity);
                }
                else if (rand > 40 && rand < 60)
                {
                    Instantiate(LargeEnemyPrefab, transform.position, Quaternion.identity);
                }
                else if (rand > 60 && rand < 80)
                {
                    Instantiate(TeleExplosion, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(shooter, transform.position, Quaternion.identity);
                }
            i++;

        }
    }
    
}
