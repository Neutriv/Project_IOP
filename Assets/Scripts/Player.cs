using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    // Use this for initialization
    void Start()
    {
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
            transform.Translate(Vector3.forward * 0.1f);
        }
        if (Input.GetKey(KeyCode.S) && dash.allowkey)
        {
            transform.Translate(Vector3.back * 0.1f);
        }
        if (Input.GetKey(KeyCode.A) && dash.allowkey)
        {
            transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.D) && dash.allowkey)
        {
            transform.Translate(Vector3.right * 0.1f);
        }
        

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
               || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            animator.SetBool("Run", true);

        else
            animator.SetBool("Run", false);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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
}
