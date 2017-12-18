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

    public float speed = 0.1f;
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
