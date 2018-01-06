using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



   public float speed = 0.1f;


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
        GameObject Obiekt = GameObject.Find("Player");
        Dash dash = Obiekt.GetComponent<Dash>();
    
        
        if (Input.GetKey(KeyCode.W) && dash.allowkey)
        {
            Ray forwardRay = new Ray(transform.position, Vector3.forward);
                if (!Physics.Raycast(forwardRay, 2*speed))
                {
                    transform.Translate(Vector3.forward * speed);
                }
        }

        if (Input.GetKey(KeyCode.S) && dash.allowkey)
        {
            Ray backRay = new Ray(transform.position, Vector3.back);
                if (!Physics.Raycast(backRay, 6*speed))
                {
                    transform.Translate(Vector3.back * speed);
                }
        }

        if (Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            Ray leftRay = new Ray(transform.position, Vector3.left);
                if (!Physics.Raycast(leftRay, 2*speed))
                {
                    transform.Translate(Vector3.left * speed);
                }
        }

        if (Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            Ray rightRay = new Ray(transform.position, Vector3.right);
                if (!Physics.Raycast(rightRay, 2*speed))
                {
                    transform.Translate(Vector3.right * speed);
                }
        }
        

        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A) 
               || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            animator.SetBool("Run",true);

        else
            animator.SetBool("Run", false);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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

   public void Shoot()
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
