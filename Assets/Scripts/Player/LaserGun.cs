using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject laser; // prefab
    private GameObject l;    // obj to instantiate
   
    public float laserSpeed;
    private bool isActive;
    private float direction;
    public int laserKills;

    public GameObject[] lasers = new GameObject[50];

    void Update()
    {
        lasers = GameObject.FindGameObjectsWithTag("Laser");
    }

    void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.L)) && isActive)
        {
            fireLaser();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = 1.0f;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = -1.0f;

        if ((int)direction == 0)
            direction = 1.0f;

        foreach(GameObject las in lasers)
        {
            if (las != null)
                if (las.GetComponent<Laser>().killShots != 0)
                {
                    laserKills += las.GetComponent<Laser>().killShots;
                    Destroy(las);
                }
            
        }
    }

    private void fireLaser()
    {
        l = Instantiate(laser) as GameObject;
        l.transform.position = this.transform.position + new Vector3(1.0f * direction, 0f, 0f);
        l.GetComponent<Rigidbody>().AddForce(new Vector3(laserSpeed * direction, 0f, 0f));
    }

    public void SetActive(bool isActive)
    {
        if (isActive != this.isActive)
            this.isActive = isActive;
    }
}

