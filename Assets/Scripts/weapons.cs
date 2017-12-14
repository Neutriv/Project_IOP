using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weapons
{
    public Player player;
    //public int sizeOfMagazine;
    public int amountOfAmmo;
    //public float range;
    //public float damage;
    public GameObject bulletSpawnPoint;
    public Sprite[] sprites;

    public System.Type classType;


    private GameObject bullet;
    public GameObject Bullet
    { get; set; }

    private GameObject gun;
    public GameObject Gun
    { get; set; }

    private Sprite sprite;
    public Sprite Sprite
    { get; set; }

    virtual public void shoot()
    {
    }
    public weapons()
    {

        GameObject Player = GameObject.Find("Player");
        player = Player.GetComponent<Player>();
        sprites = player.sprites;
        Bullet = player.nbullet;
        Gun = player.ngun;
    }
    

    public void equip(GameObject w)
    {
        GameObject Ammo_0 = GameObject.Find("Ammo_0");
        Sprite old = Ammo_0.GetComponent<SpriteRenderer>().sprite;
        Ammo_0.GetComponent<SpriteRenderer>().sprite = w.GetComponent<SpriteRenderer>().sprite;
        w.GetComponent<SpriteRenderer>().sprite = old;
      
    }

    public void create(System.String name, weapons weapon, Vector3 pos)
    {
        GameObject objToSpawn = new GameObject(name);
        objToSpawn.AddComponent<BoxCollider>();
        objToSpawn.GetComponent<BoxCollider>().isTrigger = true;
        objToSpawn.AddComponent<SpriteRenderer>();
        objToSpawn.AddComponent<weaponSwap>();
        objToSpawn.GetComponent<weaponSwap>().player = player;
        objToSpawn.GetComponent<weaponSwap>().classType = weapon.GetType();
        objToSpawn.GetComponent<SpriteRenderer>().sprite = weapon.Sprite;
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
    public rangedWeapons()
    {
        Sprite = sprites[0];
    }
    override public void shoot()
    {
          
                
            Object.Instantiate(Bullet.transform, Gun.transform.position, Gun.transform.rotation);   //inny rodzaj strzelania?
            
    }

}



public class Weapon1 : weapons
{
    Quaternion bulletAngle;
    public Weapon1()
    {
        Sprite = sprites[1];

    }
    override public void shoot()
    {
            for (int i = 0; i < 8; i++)
            {
                bulletAngle = Quaternion.Euler(new Vector3(0, (Random.Range(-22f, 22f)), 0));
                Object.Instantiate(Bullet.transform, Gun.transform.position, bulletAngle*Gun.transform.rotation);
      
        }
    }
}


public class Weapon2 : weapons
{
    public Weapon2()
    {
        Sprite = sprites[2];

    }
    override public void shoot()
    {
            Object.Instantiate(Bullet.transform, Gun.transform.position, Gun.transform.rotation);
     
    }
}