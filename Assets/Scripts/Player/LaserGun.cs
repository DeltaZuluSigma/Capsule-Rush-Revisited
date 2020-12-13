using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public Laser laser;
    public float laserSpeed;
    private bool isActive;
    private float direction;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftAlt)) && isActive)
            fireLaser();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = 1.0f;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = -1.0f;

        if ((int) direction == 0)
            direction = 1.0f;
    }

    private void fireLaser()
    {
        Laser l = Instantiate(laser) as Laser;
        l.transform.position = this.transform.position + new Vector3(1.0f * direction, 0f, 0f);
        l.GetComponent<Rigidbody>().AddForce(new Vector3(laserSpeed * direction, 0f, 0f));
    }

   public void SetActive(bool isActive)
    {
        if (isActive != this.isActive)
            this.isActive = isActive;
    }
}

