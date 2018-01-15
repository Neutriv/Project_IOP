using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
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

    public bool shooting_off=false;
    
    public float speed = 0.1f;

    public int skill_point = 0;
    public bool dash_lvl1 = false;
    public bool dash_lvl2 = false;
    public bool Immaterial_lvl1 = false;
    public bool Immaterial_lvl2 = false;
    public bool Heal_lvl1 = false;
    public bool Heal_lvl2 = false;

    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
        myRig = GetComponent<Rigidbody>();
        animator = gunpoconiewiem.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if(skill_point > 0)
        {
            if(Input.GetKeyUp(KeyCode.Alpha1) && !dash_lvl1)
            {
                dash_lvl1 = true;
                skill_point = skill_point - 1;
            }
            else if(Input.GetKeyUp(KeyCode.Alpha1) && !dash_lvl1)
            {
                dash_lvl1 = false;
                dash_lvl2 = true;
                skill_point = skill_point - 1;
            }

            if(Input.GetKeyUp(KeyCode.Alpha1) && !Immaterial_lvl1)
            {
                Immaterial_lvl1 = true;
                skill_point = skill_point - 1;
            }
            else if (Input.GetKeyUp(KeyCode.Alpha1) && !Immaterial_lvl2)
            {
                Immaterial_lvl1 = false;
                Immaterial_lvl2 = true;
                skill_point = skill_point - 1;
            }

            if(Input.GetKeyUp(KeyCode.Alpha1) && !Heal_lvl1)
            {
                Heal_lvl1 = true;
                skill_point = skill_point - 1;
            }
            else if (Input.GetKeyUp(KeyCode.Alpha1) && !Heal_lvl2)
            {
                Heal_lvl1 = false;
                Heal_lvl2 = true;
                skill_point = skill_point - 1;
            }
                
        }

        if (currentHp>maxHp)
        {
            currentHp = maxHp;
        }

        GameObject Obiekt = GameObject.Find("Player");
        Dash dash = Obiekt.GetComponent<Dash>();
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (speed / 2));

        }
        
        */
        
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(forwardRay, 4 * speed))
            {
                transform.Translate(Vector3.forward * ((speed * Mathf.Sqrt(2)))/2);
            }
            if (!Physics.Raycast(leftRay, 4 * speed))
            {
                transform.Translate(Vector3.left * ((speed * Mathf.Sqrt(2)))/2);
            }
        }
        

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(forwardRay, 4 * speed))
            {
                transform.Translate(Vector3.forward * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if(!Physics.Raycast(rightRay, 4 * speed))
            {
                transform.Translate(Vector3.right * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            Ray backRay = new Ray(transform.position, Vector3.back);
            Ray leftRay = new Ray(transform.position, Vector3.left);
            if (!Physics.Raycast(backRay, 6 * speed))
            {
                transform.Translate(Vector3.back * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if(!Physics.Raycast(leftRay, 4 * speed))
            {
                transform.Translate(Vector3.left * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            Ray backRay = new Ray(transform.position, Vector3.back);
            Ray rightRay = new Ray(transform.position, Vector3.right);
            if (!Physics.Raycast(backRay, 6 * speed))
            {
                transform.Translate(Vector3.back * ((speed * Mathf.Sqrt(2))) / 2);
            }
            if(!Physics.Raycast(rightRay, 4 * speed))
            {
                transform.Translate(Vector3.right * ((speed * Mathf.Sqrt(2))) / 2);
            }
        }

        else if (Input.GetKey(KeyCode.W) && dash.allowkey)
        {
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
                if (!Physics.Raycast(forwardRay, 4*speed))
                {
                    transform.Translate(Vector3.forward * speed);
                }
        }

        else if (Input.GetKey(KeyCode.S) && dash.allowkey)
        {
            Ray backRay = new Ray(transform.position, Vector3.back);
                if (!Physics.Raycast(backRay, 6*speed))
                {
                    transform.Translate(Vector3.back * speed);
                }
        }

        else if (Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            Ray leftRay = new Ray(transform.position, Vector3.left);
                if (!Physics.Raycast(leftRay, 4*speed))
                {
                    transform.Translate(Vector3.left * speed);
                }
        }

        else if (Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            Ray rightRay = new Ray(transform.position, Vector3.right);
                if (!Physics.Raycast(rightRay, 4*speed))
                {
                    transform.Translate(Vector3.right * speed);
                }
        }

        



        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A) 
               || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            animator.SetBool("Run",true);

        else
            animator.SetBool("Run", false);

        if (!shooting_off)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        if (isD == true)
        {
            if(canBeDamaged == true)
                StartCoroutine(Wait());


        }

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

        canBeDamaged = true;isD = false;
        StopAllCoroutines();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            
            if (isD != true)
                isD = true;
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
}
