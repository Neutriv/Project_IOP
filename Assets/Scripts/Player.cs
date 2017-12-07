using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gunpoconiewiem;
    public float waitTime;
    private Animator animator;

    public float moveSpeed;
    private Rigidbody myRig;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GameObject nbullet;
    public GameObject ngun;
    public weapons bron;
    public Sprite nsprite;
    //  public int numberOfBullets;
    // Use this for initialization
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        animator = gunpoconiewiem.GetComponent<Animator>();
        bron = new rangedWeapons(nbullet, ngun, nsprite);
        bron.equip();
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
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
               || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            animator.SetBool("Run", true);

        else
            animator.SetBool("Run", false);

        if (Input.GetMouseButtonDown(0))
        {
            bron.shoot();
        }
    }

    void FixedUpdate()
    {
        myRig.velocity = moveVelocity;
    }
}
