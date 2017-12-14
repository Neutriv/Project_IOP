using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHp;
    public int currentHp;
    public bool isD;
    public bool canBeDamaged = true;
    public GameObject SpriteRender;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public float waitTime;
    private Animator animator;

    public float moveSpeed;
    private Rigidbody myRig;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GameObject gun;
    
    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
        myRig = GetComponent<Rigidbody>();
        animator = SpriteRender.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.1f);
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
