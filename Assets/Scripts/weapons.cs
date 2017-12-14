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
    public Sprite[] sprites;
    virtual public void shoot()
    {
    }
    public weapons()
    {

        GameObject Player = GameObject.Find("Player");
        player = Player.GetComponent<Player>();
        sprites = player.sprites;

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
    public void swap(weapons w1, weapons w2)
    {
        weapons w = w1;
        w1 = w2;
        w2 = w;
    }
    public void create(System.String name, weapons weapon, Vector3 pos)
    {
        GameObject objToSpawn = new GameObject(name);
        objToSpawn.AddComponent<BoxCollider>();
        objToSpawn.GetComponent<BoxCollider>().isTrigger = true;
        objToSpawn.AddComponent<SpriteRenderer>();
        objToSpawn.AddComponent<weaponSwap>();
        objToSpawn.GetComponent<weaponSwap>().player = player;
        objToSpawn.GetComponent<SpriteRenderer>().sprite = sprite;
        objToSpawn.transform.parent = GameObject.Find("Weapons").transform;
        objToSpawn.transform.position = pos;
        objToSpawn.transform.rotation = new Quaternion(90, 0, 0, 90);
        objToSpawn.transform.localScale = new Vector3(5, 5, 5);
        objToSpawn.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        objToSpawn.GetComponent<BoxCollider>().size = new Vector3(0.09f, 0.14f, 0.2f);
    }
}


public class rangedWeapons: weapons
{
    public rangedWeapons(GameObject nbullet, GameObject ngun)
    {
        bullet = nbullet;
        gun = ngun;
        sprite = sprites[0];

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
    Quaternion bulletAngle;
    public Weapon1(GameObject nbullet, GameObject ngun)
    {
        bullet = nbullet;
        gun = ngun;
        sprite = sprites[1];

    }
    override public void shoot()
    {
        if (numberOfBullets != 0)
        {
           // numberOfBullets--;
            for (int i = 0; i < 4; i++)
            {
                /* ACCURACY */
                //Player.bulletRot = Player.mouseRotation;
                bulletAngle = Quaternion.Euler(new Vector3(0, (Random.Range(-12f, 12f)), 0));
                // Make a bullet at the position of the player in the direction of                         the mouse
                Object.Instantiate(bullet.transform, gun.transform.position, bulletAngle*gun.transform.rotation);
            }
           // Object.Instantiate(bullet.transform, gun.transform.position, gun.transform.rotation);
        }
    }
}


public class Weapon2 : weapons
{
    public Weapon2(GameObject nbullet, GameObject ngun)
    {
        bullet = nbullet;
        gun = ngun;
        sprite = sprites[2];

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