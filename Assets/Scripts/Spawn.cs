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
                int rand = RandNum.GetRandomNumber(0,99);

                if (rand < 20)
                {
                    Instantiate(SmallEnemyPrefab, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
                }
                else if (rand > 20 && rand < 40)
                {
                    Instantiate(MedEnemyPrefab, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
                }
                else if (rand > 40 && rand < 45)
                {
                    Instantiate(LargeEnemyPrefab, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
                }
                else if (rand > 45 && rand < 70)
                {
                    Instantiate(TeleExplosion, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
                }
                else if(rand > 70 && rand < 90)
                {
                    Instantiate(shooter, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
                }
             else
                {

                }
             i++;

        }
    }
    
}
