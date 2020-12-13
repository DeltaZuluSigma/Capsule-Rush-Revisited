using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Wall" || col.gameObject.tag == "Ground")
            Destroy(this.gameObject);

        if (col.gameObject.tag == "pSpeedBoost" || col.gameObject.tag == "pLaserGun" || col.gameObject.tag == "pInvincibility"
            || col.gameObject.tag == "pAntiGravity" || col.gameObject.tag == "pTeleport" || col.gameObject.tag == "Coin" || col.gameObject.tag == "Live" || col.gameObject.tag == "Player")
        {
            //  Physics.IgnoreCollison(this.GetComponent<Collider>(), col.gameObject.GetComponent<Collider>());
        }
   }
}
