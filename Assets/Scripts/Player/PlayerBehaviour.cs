using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerController controller;
    public GameObject spawnPoint;                // reference to spawn in first gen block of level
    public LaserGun laserGun;               // ref to players laser gun
    public GameObject tMarker;              // place to teleport
    public GameObject feet;

    //for death
    private bool isDead;

    //HUD
    public Text cText;
    public Text lText;
    public Text dText;
    //p hud
    public Image iLaser;
    public Image iSpeed;
    public Text tSpeed;
    public Image iInv;
    public Text tInv;
    public Image iTele;
    public Image iGrav;

    //powerups
    // laser
    public bool canShoot;  // controls if lasergun is active
    //invincible
    public bool isInvincible;
    private float iTimer;      // time holder for invincibility
    // speed boost
    public bool hasSpeedBoost;
    private float sTimer;       // time holder for speed boost
    //gravity
    private bool flipGrav;
    private bool isUpsideDown;
    private float currentGrav;  // ref to orginal gravity
    public float antiGrav;      // a negative number to counteract the gravity on the player
    //teleporter
    private bool canTeleport;
    public float tDistance;      // distance between player and tMarker

    // collectables
    public int lives;
    public int coins;
    private int coinChecker;


    void Start()
    {

        isDead = false;

        isInvincible = false;
        iTimer = 10.0f;

        hasSpeedBoost = false;
        sTimer = 5.0f;

        iLaser.enabled = false;
        iSpeed.enabled = false;
        tSpeed.text = "";
        iInv.enabled = false;
        tInv.text = "";
        iTele.enabled = false;
        iGrav.enabled = false;

        // currentGrav = GetComponent<Rigidbody>().gravityScale;
    }

    void FixedUpdate()
    {
        invincibleTimer();
        speedBoostTimer();

        checkPowerUp();
    }

    void OnCollisionEnter(Collision col)
    {
        setPowerUp(col.gameObject.tag);

        if(col.gameObject.GetComponent<PowerUp>())
        {
            Destroy(col.gameObject);
        }

        if ((col.gameObject.tag == "Obstacle") && !isInvincible)
        {
            lives--;
            deathCheck();

            if (hasSpeedBoost)
                hasSpeedBoost = false;
            else if (canShoot)
                canShoot = false;
        }

        if (col.gameObject.tag == "Enemy" && !isInvincible)
        {
            lives--;
            deathCheck();

            if (hasSpeedBoost)
                hasSpeedBoost = false;
            else if (canShoot)
                canShoot = false;
        }

        if (col.gameObject.tag == "Coin")
        {
            collectCoin();
        }

        if (col.gameObject.tag == "Live")
        {
            lives++;
        }

    }


    public void deathCheck()
    {
        if (lives < 0)
        {
            lives = 0;
            isDead = true;
            respawn();
        }
    }

    public void collectCoin()
    {
        coins++;
        coinChecker++;
        if (coinChecker >= 100)
        {
            coinChecker -= 100;
            lives++;
        }
        cText.text = "" + coins;
    }

    public void setPowerUp(string tag)
    {
        switch (tag)
        {
            case "pLaserGun":
                canShoot = true;
                iLaser.enabled = true;
                break;

            case "pInvincibility":
                isInvincible = true;
                iInv.enabled = true;
                break;

            case "pSpeedBoost":
                hasSpeedBoost = true;
                iSpeed.enabled = true;
                break;

            case "pAntiGravity":
                if (flipGrav == true)
                {
                    flipGrav = false;
                    iGrav.enabled = false;
                    // FlipUp();
                }
                else
                {
                    flipGrav = true;
                    iGrav.enabled = true;
                    // FlipUp();
                }
                break;

            case "pTeleport":
                canTeleport = true;
                iTele.enabled = true;
                break;

            default:
                break;
        }
    }

    private void checkPowerUp()
    {
        checkLaserGun();
        checkInvincible();
        checkSpeedBoost();
        //checkAntiGrav();
    }

    private void checkLaserGun()
    {
        if (canShoot == true)
            laserGun.SetActive(true);

        else
        {
            laserGun.SetActive(false);
            iLaser.enabled = false;
        }
    }

    private void checkInvincible()
    {
        if (iTimer <= 0)
        {
            isInvincible = false;
            iInv.enabled = false;
            iTimer = 10.0f;
        }
    }

    private void invincibleTimer()
    {
        if (isInvincible)
        {
            iTimer -= Time.deltaTime;
            tInv.text = "" + System.Math.Round(iTimer, 2);
        }
        else iTimer = 10.0f;
    }

    private void checkSpeedBoost()
    {
        if (sTimer <= 0.0f)
        {
            controller.walkSpeed /= 2;
            controller.runSpeed /= 2;
            hasSpeedBoost = false;
            iSpeed.enabled = false;
            sTimer = 5.0f;
        }
    }

    private void speedBoostTimer()
    {
        if (hasSpeedBoost)
        {
            if (sTimer > 0.0f)
            {
                controller.walkSpeed *= 2;
                controller.runSpeed *= 2;
            }

            sTimer -= Time.deltaTime;
            tSpeed.text = "" + System.Math.Round(sTimer, 1);
        }

    }

    /*private void checkAntiGrav()
    {
        if (flipGrav)
            GetComponent<Rigidbody>().gravityScale = antiGrav;
        else GetComponent<Rigidbody>().gravityScale = currentGrav;
    }*/

    /*  private void FlipUp()
      {
          // switch direction the player is labelled as facing
          isUpsideDown = !isUpsideDown;

          // Multiply the player's y local scale by -1.
          Vector3 scale = transform.localScale;
          scale.y *= -1;
          transform.localScale = scale;
      }*/

    /* private void teleportMarker()
     {
         if (canTeleport)
         {
             GameObject t = Instantiate(tMarker) as GameObject;

             t.transform.position.x += tDistance;
         }
     }*/


    private void respawn()
    {
        this.transform.position = spawnPoint.transform.position;
    }
}