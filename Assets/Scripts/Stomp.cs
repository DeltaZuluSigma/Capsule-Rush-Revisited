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
        //Debug.Log("si");

        if(this.GetComponent<Collider>().tag == "Head")
        {
            Debug.Log("aa");
            if (col.GetComponent<Collider>().tag == "Player")
            {
                Debug.Log("bb");
            }
            if (this.GetComponent<Collider>().tag == "Enemy")
            {
                Debug.Log("Enemy");
            }
        }

        if (this.GetComponent<Collider>().tag == "Enemy")
        {
            Debug.Log("Enemy");
        }


        
        //fix capsule coolider size
        if (col.GetComponent<Collider>().tag == "Player" && this.GetComponent<Collider>().tag == "Head")
        {
            Debug.Log(col.GetComponent<Collider>().tag);
            Debug.Log(this.GetComponent<Collider>().tag);
            Destroy(this.gameObject);
        }
        
         

    }
}
