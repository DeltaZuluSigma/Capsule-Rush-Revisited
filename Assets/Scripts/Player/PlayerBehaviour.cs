using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public PlayerController controller;
    private GameObject[] spawnPoint = new GameObject[1];                // reference to spawn in first gen block of level
    public LaserGun laserGun;               // ref to players laser gun
    public GameObject tMarker;              // place to teleport
    private GameObject t;
    public GameObject foot;

    public GameObject nextLevel;
    public GameObject mmButton;

    public Material[] mats = new Material[7];

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

    private int kills;

    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            initializeData();
            saveData();
            loadData();
        }
        else loadData();
    }

    void Start()
    {

        Time.timeScale = 1;

        iLaser.enabled = false;
        iSpeed.enabled = false;
        tSpeed.text = "";
        iInv.enabled = false;
        tInv.text = "";
        iTele.enabled = false;
        iGrav.enabled = false;
        nextLevel.SetActive(false);

        isDead = false;

        spawnPlayer();
    }

    void FixedUpdate()
    {
        invincibleTimer();
        speedBoostTimer();
        antiGravity();
        teleportMarker();

        checkPowerUp();

        changeColour();

        deathCheck();

        saveData();

        cText.text = "x" + coins;
        lText.text = "x" + lives;
        dText.text = "x" + (kills + laserGun.laserKills);


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("powerup"))
            setPowerUp(col.gameObject.tag);


        if ((col.gameObject.tag == "Obstacle") && !isInvincible)
        {
            takeDamage();
            StartCoroutine(Flash());
        }

        if (col.gameObject.tag == "Coin")
        {
            collectCoin();
        }

        if (col.gameObject.tag == "Live")
        {
            lives++;
        }

        if(col.gameObject.tag == "Death")
        {
            if(!isInvincible)
            takeDamage();
            GameObject[] bases = new GameObject[12];
            bases = GameObject.FindGameObjectsWithTag("Base");

            for(int i = 0; i <= bases.Length-1; i++)
            {
                if ((this.transform.position.x >= bases[i].transform.position.x - 30) && (this.transform.position.x <= bases[i].transform.position.x + 30) && (this.transform.position.y >= bases[i].transform.position.y - 100) && (this.transform.position.y <= bases[i].transform.position.y + 100))
                    this.transform.position = new Vector3(bases[i].transform.position.x, bases[i].transform.position.y + 3.0f, 0.0f);
            }
        }

        if (col.gameObject.tag == "End")
        {
            mmButton.SetActive(true);
            nextLevel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("enemy"))
            if (col.gameObject.tag == "Head")
            {
                Destroy(col.gameObject);
                kills++;
            }
            else if (col.gameObject.tag == "Enemy" && !isInvincible)
            {
                takeDamage();
                StartCoroutine(Flash());
            }
            else if (col.gameObject.tag == "Enemy" && isInvincible)
            {
                Destroy(col.gameObject);
                kills++;
            }
    }

    public void deathCheck()
    {
        if (lives < 0)
        {
            isDead = true;
            respawnPlayer();
        }
    }

    public void takeDamage()
    {
        lives--;
        deathCheck();

        if (hasSpeedBoost)
            hasSpeedBoost = false;
        else if (canTeleport)
            canTeleport = false;
        else if (canShoot)
            canShoot = false;
    }

    IEnumerator Flash()
    {
        this.gameObject.GetComponent<Renderer>().material = mats[6];
        yield return new WaitForSeconds(0.1f);
        changeColour();
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
    }

    public void setPowerUp(string tag)
    {
        switch (tag)
        {
            case "pLaserGun":
                canShoot = true;
                iLaser.enabled = true;
                break;

            case "pInvincible":
                isInvincible = true;
                iInv.enabled = true;
                tInv.enabled = true;
                break;

            case "pSpeedBoost":
                hasSpeedBoost = true;
                iSpeed.enabled = true;
                tSpeed.enabled = true;
                break;

            case "pAntiGravity":
                if (flipGrav == true)
                {
                    flipGrav = false;
                    iGrav.enabled = false;
                    isUpsideDown = false;

                    Vector3 scale = transform.localScale;
                    if (scale.y < 0)
                        scale.y *= -1;
                    transform.localScale = scale;
                }
                else
                {
                    flipGrav = true;
                    iGrav.enabled = true;
                    isUpsideDown = true;

                    Vector3 scale = transform.localScale;
                    scale.y *= -1;
                    transform.localScale = scale;

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
        checkAntiGrav();
        checkTeleport();
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
            tInv.enabled = false;
            iTimer = 5.0f;
        }
    }

    private void invincibleTimer()
    {
        if (isInvincible)
        {
            iTimer -= Time.deltaTime;
            tInv.text = "" + (int)iTimer;
        }
        else iTimer = 5.0f;
    }

    private void checkSpeedBoost()
    {
        if (sTimer <= 0.0f)
        {
            controller.walkSpeed = 30;
            controller.runSpeed = 50;
            hasSpeedBoost = false;
            iSpeed.enabled = false;
            tSpeed.enabled = false;
            sTimer = 3.1f;
        }
    }

    private void speedBoostTimer()
    {
        if (hasSpeedBoost)
        {
            if (sTimer <= 3.0f)
            {
                controller.walkSpeed  = 75;
                controller.runSpeed = 90;
            }

            sTimer -= Time.deltaTime;
            tSpeed.text = "" + (int)sTimer;
        }

    }

    private void checkAntiGrav()
    {
        if (flipGrav)
        {
            controller.rigidBody.useGravity = false;
        }
        else
        {
            controller.rigidBody.useGravity = true;
        }
    }

    private void antiGravity()
    {
        if (isUpsideDown)
        {
            controller.rigidBody.AddForce(new Vector3(0f, antiGrav, 0f));
            if (controller.jumpForce > 0)
                controller.jumpForce = -controller.jumpForce;
        }
        else
        {
            if (controller.jumpForce <= 0)
                controller.jumpForce = -controller.jumpForce;
        }
    }

    private void teleportMarker()
     {
         if (canTeleport && t == null)
         {
            t = Instantiate(tMarker) as GameObject;
         }
         if(t != null)
            t.transform.position = new Vector3(this.transform.position.x + tDistance, this.transform.position.y, 0.0f);
    }

     private void checkTeleport()
     {
        if(canTeleport && Input.GetKeyDown(KeyCode.T) && t != null)
        {
            this.transform.position = new Vector3(t.transform.position.x, t.transform.position.y + 2.0f, 0.0f);
            canTeleport = false;
            iTele.enabled = false;
            Destroy(t);
        }
    }
   
    private void spawnPlayer()
    {
        GameObject spawnP = GameObject.FindWithTag("Spawn");
        if(spawnPoint != null)
        { 
            this.transform.position = new Vector3(spawnP.transform.position.x, spawnP.transform.position.y + 5f, 0.0f);
        }
    }

    private void respawnPlayer()
    {
        if (isDead)
        {
            Time.timeScale = 0;
            mmButton.SetActive(true);
            this.transform.position = new Vector3(spawnPoint[0].transform.position.x, spawnPoint[0].transform.position.y + 5f, 0.0f);
            lives = 0;
        }
    }

    public void initializeData()
    {
        lives = 3;
        coins = 0;
        kills = 0;

        canShoot = false;
        hasSpeedBoost = false;
        isInvincible = false;
        canTeleport = false;
        flipGrav = false;

        iTimer = 5.0f;
        sTimer = 3.1f;
    }

    public void saveData()
    {
        // collectables
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.SetInt("coins", coins);
        //power ups
        PlayerPrefs.SetInt("pLaser", canShoot ? 1 : 0);
        PlayerPrefs.SetInt("pSpeedBoost", hasSpeedBoost ? 1 : 0);
        PlayerPrefs.SetInt("pInvincible", isInvincible ? 1 : 0);
        PlayerPrefs.SetInt("pGravity", flipGrav ? 1 : 0);
        PlayerPrefs.SetInt("pTeleport", canTeleport ? 1 : 0);
        //timers
        if (hasSpeedBoost == true)
            PlayerPrefs.SetFloat("sTimer", sTimer);
        else PlayerPrefs.SetFloat("sTimer", 0.0f);

        if (isInvincible == true)
            PlayerPrefs.SetFloat("iTimer", iTimer);
        else PlayerPrefs.SetFloat("iTimer", 0.0f);
    }

    public void loadData()
    {
        // collectables
        lives = PlayerPrefs.GetInt("lives", 3);

        coins = PlayerPrefs.GetInt("coins", 0);

        //power ups
        if (PlayerPrefs.GetInt("pLaser", 0) == 1)
            canShoot = true;
        else canShoot = false;

        if (PlayerPrefs.GetInt("pSpeedBoost", 0) == 1)
            hasSpeedBoost = true;
        else hasSpeedBoost = false;

        if (PlayerPrefs.GetInt("pInvincible", 0) == 1)
            isInvincible = true;
        else isInvincible = false;

        if (PlayerPrefs.GetInt("pGravity", 0) == 1)
            flipGrav = true;
        else flipGrav = false;

        if (PlayerPrefs.GetInt("pTeleport", 0) == 1)
            canTeleport = true;
        else canTeleport = false;

        // timers
        if (PlayerPrefs.GetFloat("sTimer", 0) != 0 && PlayerPrefs.GetInt("pSpeedBoost") == 1)
            sTimer = PlayerPrefs.GetFloat("sTimer");
        else sTimer = 5.0f;

        if (PlayerPrefs.GetFloat("iTimer", 0) != 0 && PlayerPrefs.GetInt("pInvincible") == 1)
            iTimer = PlayerPrefs.GetFloat("iTimer");
        else iTimer = 3.1f;
    }

    public void changeColour()
    {
        if (flipGrav == true)
            this.gameObject.GetComponent<Renderer>().material = mats[5];
        else if (canTeleport == true)
            this.gameObject.GetComponent<Renderer>().material = mats[4];
        else if (isInvincible == true)
            this.gameObject.GetComponent<Renderer>().material = mats[3];
        else if (hasSpeedBoost == true)
            this.gameObject.GetComponent<Renderer>().material = mats[2];
        else if (canShoot == true)
            this.gameObject.GetComponent<Renderer>().material = mats[1];
        else this.gameObject.GetComponent<Renderer>().material = mats[0];

        laserGun.gameObject.GetComponent<Renderer>().material = this.gameObject.GetComponent<Renderer>().material;
    }
}