using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SmallEnemyPrefab;
    public GameObject MedEnemyPrefab;
    public GameObject LargeEnemyPrefab;


    public void smallSpawn(Vector3 v3)
    {
        
        Instantiate(SmallEnemyPrefab, v3,Quaternion.identity);
    }

    public void medSpawn(Vector3 v3)
    {
        Instantiate(MedEnemyPrefab, v3, Quaternion.identity);
    }

    public void largeSpawn(Vector3 v3)
    {
        Instantiate(LargeEnemyPrefab , v3, Quaternion.identity);
    }
    
}
