using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        //Replace CapsuleBlue with whatever the tag name of the
        //Player character is. Note: If the player has multiple tags
        //due to powerups, then use || to distinguish each.
        //E.g. col.gameObject.tag == "CapsuleBlue" || col.gameObject.tag == "CapsuleRed" || etc.
        if (col.gameObject.tag == "CapsuleBlue")
        {
            this.gameObject.SetActive(false);
        }
    }
}
