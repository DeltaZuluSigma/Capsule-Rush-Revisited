using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //Vector3 loc = new Vector3(1, 3, 3);
        //Instantiate(SmallEnemyPrefab, loc, Quaternion.identity);
        //Destroy(gameObject);
        //Destroy(this.gameObject);
        if (col.GetComponent<Collider>().tag == "Foot" && this.GetComponent<Collider>().tag == "Head")
        {
            Destroy(this.gameObject);
        }
        
         

    }
}
