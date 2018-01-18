using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Player : MonoBehaviour
{


    public GameObject lose;
    public RuntimeAnimatorController silver, red, gold;
    public bool canShoot = true;
    public bool shooting_off = false;

    public int skill_point;
    public bool dash_lvl1;
    public bool dash_lvl2;
    public bool Immaterial_lvl1;
    public bool Immaterial_lvl2;
    public bool Heal_lvl1;
    public bool Heal_lvl2;
    public bool dmg;

    StreamWriter sw;
    public int maxHp;
    public int currentHp;
    public bool isD;
    public bool canBeDamaged = true;
    public GameObject gunpoconiewiem;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public float waitTime;
    private Animator animator;

    public float moveSpeed;
    private Rigidbody myRig;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GameObject gun;

    public GameObject nbullet;
    public GameObject ngun;
    public weapons bron;
    public Sprite nsprite;


    public int numberOfBullets = 10;
    public Sprite[] sprites;


    public GameObject AmmoTextField;
    public GameObject HealthUIAmmount;

    public int gainedXp = 0;
    public float speed = 0.1f;

    // Use this for initialization
    void Start()
    {

        currentHp = maxHp;
        myRig = GetComponent<Rigidbody>();
        animator = gunpoconiewiem.GetComponent<Animator>();
        bron = new rangedWeapons();
        
        skill_point = 1;
        dash_lvl1 = false;
        dash_lvl2 = false;
        Immaterial_lvl1 = false;
        Immaterial_lvl2 = false;
        Heal_lvl1 = false;
        Heal_lvl2 = false;
        dmg = true;

        //zczytuje wartość dla dash i tp

        string content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "dash.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
            dash_lvl1 = true;
        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "teleport.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
        {
            dash_lvl1 = false;
            dash_lvl2 = true;
        }

        //zczytuje wartość dla heal 1 i 2

        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "heal1.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
            Heal_lvl1 = true;
        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "heal2.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
        {
            Heal_lvl1 = false;
            Heal_lvl2 = true;
        }

        //zczytuje wartość dla immaterial 1 i 2

        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "immaterial1.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
            Immaterial_lvl1 = true;
        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "immaterial2.txt"))
        {
            content = reader.ReadToEnd();
        }
        if (content == "1")
        {
            Immaterial_lvl1 = false;
            Immaterial_lvl2 = true;
        }

        //zczytuje wartość currentSkin aby ustawić animatora
        content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "currentSkin.txt"))
        {
            content = reader.ReadToEnd();
        }
        if(content == "0")
        {
            animator.runtimeAnimatorController = silver as RuntimeAnimatorController;
        }
        else if (content == "1")
        {
            animator.runtimeAnimatorController = red as RuntimeAnimatorController;
        }
        else if (content == "2")
        {
            animator.runtimeAnimatorController = gold as RuntimeAnimatorController;
        }



    }

    // Update is called once per frame
    void Update()
    {   

        if(currentHp <=0)
        {
            lose.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
        
        //animator
        if (currentHp == 0)
        {
            animator.SetBool("Death", true);
            Death(); //jak umiera
        }
        if(gameObject.GetComponent<Dash>().dashing == true)
        {
            animator.SetBool("Dash", true);
        }
        if (gameObject.GetComponent<Dash>().dashing != true)
        {
            animator.SetBool("Dash", false);
        }

        if (gameObject.GetComponent<Teleport_Dash_lvl2>().teleporting == true)
        {
            animator.SetBool("Teleport", true);
        }
        if (gameObject.GetComponent<Teleport_Dash_lvl2>().teleporting != true)
        {
            animator.SetBool("Teleport", false);
        }

        if (gameObject.GetComponent<Immaterial>().invincible == true)
        {
            //invincible
        }
        if (gameObject.GetComponent<Immaterial>().invincible != true)
        {
            //invincible
        }

        if (gameObject.GetComponent<Immaterial_lvl2>().invincibleRainbow == true)
        {
            //invincible
        }
        if (gameObject.GetComponent<Immaterial_lvl2>().invincibleRainbow != true)
        {
            //invincible
        }

       





        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        GameObject Obiekt = GameObject.Find("Player");
        Dash dash = Obiekt.GetComponent<Dash>();
        

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("Run", true);
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(forwardRay, 4 * speed))
            {
                transform.Translate(Vector3.forward * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if (!Physics.Raycast(leftRay, 4 * speed))
            {
                transform.Translate(Vector3.left * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }


        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Run", true);
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(forwardRay, 4 * speed))
            {
                transform.Translate(Vector3.forward * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if (!Physics.Raycast(rightRay, 4 * speed))
            {
                transform.Translate(Vector3.right * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && dash.allowkey)
        {

            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("Run", true);
            Ray backRay = new Ray(transform.position, Vector3.back);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(backRay, 6 * speed))
            {
                transform.Translate(Vector3.back * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if (!Physics.Raycast(leftRay, 4 * speed))
            {
                transform.Translate(Vector3.left * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Run", true);
            Ray backRay = new Ray(transform.position, Vector3.back);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(backRay, 6 * speed))
            {
                transform.Translate(Vector3.back * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if (!Physics.Raycast(rightRay, 4 * speed))
            {
                transform.Translate(Vector3.right * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }

        else if (Input.GetKey(KeyCode.W) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Run", true);
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            if (!Physics.Raycast(forwardRay, 4 * speed))
            {
                transform.Translate(Vector3.forward * speed);
            }
        }

        else if (Input.GetKey(KeyCode.S) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Run", true);
            Ray backRay = new Ray(transform.position, Vector3.back);
            if (!Physics.Raycast(backRay, 6 * speed))
            {
                transform.Translate(Vector3.back * speed);
            }
        }

        else if (Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("Run", true);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(leftRay, 4 * speed))
            {
                transform.Translate(Vector3.left * speed);
            }
        }

        else if (Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            gunpoconiewiem.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Run", true);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(rightRay, 4 * speed))
            {
                transform.Translate(Vector3.right * speed);
            }
        }

     
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A)
               || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            animator.SetBool("Run", false);

        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot == true && !shooting_off)
            {
                if (numberOfBullets > 0)
                {
                    numberOfBullets--;
                    bron.shoot();

                }
            }
        }

        if (isD == true)
        {
            if (canBeDamaged == true)
                StartCoroutine(Wait());


        }
        
        //UI, zmiana tekstów i pasków wszelakich

        Text ammotextfield = AmmoTextField.GetComponent<Text>();
        ammotextfield.text = "Ammo: " + numberOfBullets;
        float hp = (float)currentHp/(float)maxHp;
        HealthUIAmmount.GetComponent<Image>().fillAmount = hp;

    }

    void FixedUpdate()
    {
        myRig.velocity = moveVelocity;

    }

    void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, gun.transform.rotation);
    }

    IEnumerator Wait()
    {


        currentHp--;
        canBeDamaged = false;
        yield return new WaitForSeconds(0.4f);

        canBeDamaged = true; isD = false;
        StopAllCoroutines();
    }

    void OnTriggerEnter(Collider other)
    {
        if (dmg)
        {
            if (other.CompareTag("projectile"))
            {

                if (isD != true)
                    isD = true;
            }
        }

        if (other.CompareTag("Rival"))
        {

            if (isD != true)
                isD = true;
        }

        if (other.CompareTag("Trap"))
        {

            if (isD != true)
                isD = true;
        }


    }
    public void Death()
    {

    }

    
}
