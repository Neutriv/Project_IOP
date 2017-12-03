using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weapons
{
    public int sizeOfMagazine;
    public int amountOfAmmo;
    public int numberOfBullets = 20;
    public float range;
    public float damage;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public GameObject gun;
    Sprite sprite;
    private void Start()
    {
    }
    virtual public void shoot()
    {
        
    }
    public weapons()
    {
        bulletSpawnPoint = GameObject.Find("Sphere1");
        Debug.Log(bulletSpawnPoint);
    }
}


public class rangedWeapons: weapons
{
    public rangedWeapons(GameObject nbullet, GameObject ngun)
    {
        bullet = nbullet;
        gun = ngun;

    }
    override public void shoot()
    {
            if (numberOfBullets != 0)
            {
                numberOfBullets--;
            Object.Instantiate(bullet.transform, bulletSpawnPoint.transform.position, gun.transform.rotation);
            }
    }
   

}

public class Weapon1 : weapons
{
    
    override public void shoot()
    {
        if (numberOfBullets != 0)
        {
            numberOfBullets--;
            Object.Instantiate(bullet.transform, bulletSpawnPoint.transform.position, gun.transform.rotation);
        }
    }
}


public class Weapon2 : weapons
{

    override public void shoot()
    {
        if (numberOfBullets != 0)
        {
            numberOfBullets--;
            Object.Instantiate(bullet.transform, bulletSpawnPoint.transform.position, gun.transform.rotation);
        }
    }

}