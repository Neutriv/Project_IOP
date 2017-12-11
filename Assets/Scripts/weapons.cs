using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weapons
{
    public Player player;
    //public int sizeOfMagazine;
    public int amountOfAmmo;
    public int numberOfBullets = 10;
    //public float range;
    //public float damage;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public GameObject gun;
    public Sprite sprite;
    virtual public void shoot()
    {
        
    }
    public weapons()
    {

    }

    public void addAmmo(int a)
    {
        numberOfBullets += a;
    }

    public void equip()
    {
        GameObject Ammo_0 = GameObject.Find("Ammo_0");
        Ammo_0.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void weaponSwap(weapons w1, weapons w2)
    {
        int bullets = w1.numberOfBullets;
        w1.numberOfBullets = w2.numberOfBullets;
        w2.numberOfBullets = bullets;

        GameObject bullet = w1.bullet;
        w1.bullet = w2.bullet;
        w2.bullet = bullet;

        Sprite current = w1.sprite;
        w1.sprite = w2.sprite;
        w2.sprite = current;



    }
}


public class rangedWeapons: weapons
{
    public rangedWeapons(GameObject nbullet, GameObject ngun, Sprite nsprite)
    {
        bullet = nbullet;
        gun = ngun;
        sprite = nsprite;

    }
    override public void shoot()
    {
            if (numberOfBullets != 0)
            {
                numberOfBullets--;
            Object.Instantiate(bullet.transform, gun.transform.position, gun.transform.rotation);   //inny rodzaj strzelania?
            }
    }

}



public class Weapon1 : weapons
{
    public Weapon1(GameObject nbullet, GameObject ngun, Sprite nsprite)
    {
        bullet = nbullet;
        gun = ngun;
        sprite = nsprite;

    }
    override public void shoot()
    {
        if (numberOfBullets != 0)
        {
            numberOfBullets--;
            Object.Instantiate(bullet.transform, gun.transform.position, gun.transform.rotation);
        }
    }
}


public class Weapon2 : weapons
{
    public Weapon2(GameObject nbullet, GameObject ngun, Sprite nsprite)
    {
        bullet = nbullet;
        gun = ngun;
        sprite = nsprite;

    }
    override public void shoot()
    {
        if (numberOfBullets != 0)
        {
            numberOfBullets--;
            Object.Instantiate(bullet.transform, gun.transform.position, gun.transform.rotation);
        }
    }
}