using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBasic : MonoBehaviour
{
	public bool canShoot = true;


	//public int maxHp;
	//public int currentHp;
	//public bool isD;
	//public bool canBeDamaged = true;
	//public GameObject gunpoconiewiem;
	public GameObject bullet;
	public GameObject bulletSpawnPoint;
	public float waitTime;
	private Animator animator;

	//public float moveSpeed;
	private Rigidbody myRig;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	public GameObject gun;

	//public GameObject nbullet;
	//public GameObject ngun;
	public weapons bron;
	//public Sprite nsprite;


	//public int numberOfBullets = 10;
	public Sprite[] sprites;


	//public GameObject AmmoTextField;
	//public GameObject HealthUIAmmount;


	public float speed = 0.1f;

	// Use this for initialization
	public void Start()
	{
		/*currentHp = maxHp;
		myRig = GetComponent<Rigidbody>();
		//animator = gunpoconiewiem.GetComponent<Animator>();
		bron = new rangedWeapons();
*/
	}

	// Update is called once per frame
	public void Update()
	{

		/*
		if (Input.GetMouseButtonDown(0))
		{
			if (canShoot == true)
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
*/
		//UI, zmiana tekstów i pasków wszelakich
		/*
		Text ammotextfield = AmmoTextField.GetComponent<Text>();
		ammotextfield.text = "Ammo: " + numberOfBullets;
		float hp = (float)currentHp/(float)maxHp;
		HealthUIAmmount.GetComponent<Image>().fillAmount = hp;
*/
	}

	void FixedUpdate()
	{
		//myRig.velocity = moveVelocity;

	}

	public void Shoot()
	{

		Instantiate(
			bullet.transform, 
			bulletSpawnPoint.transform.position,
			gun.transform.rotation);

	}

	/*IEnumerator Wait()
	{


		currentHp--;
		canBeDamaged = false;
		yield return new WaitForSeconds(0.4f);

		canBeDamaged = true; isD = false;
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


	}*/
}
