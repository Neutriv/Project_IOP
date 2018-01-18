using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Death : MonoBehaviour {

    public GameObject sprite;
    public GameObject enemy;
    public GameObject ThisObject;
    public int HP;
    public Animator anim;
    public int xp;
    public StreamWriter sw;

    // Use this for initialization
    void Start () {
        anim = sprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        HP = enemy.GetComponent<enemy>().currentHp;
        if (HP <= 0)
        {
           
           StartCoroutine(Wait());
            
        }
	}
    
    IEnumerator Wait()
    {   anim.SetBool("Death", true);
        yield return new WaitForSeconds(2f);
        //jeszcze dodać w playerze ile punktów dostał w tym przejściu.
        string content = string.Empty;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/data/" + "exp.txt"))
        {
            content = reader.ReadToEnd();
        }
        int x = System.Convert.ToInt32(content);
        sw = new StreamWriter(Application.dataPath + "/data/" + "exp.txt");
        sw.Write((x+xp).ToString());
        sw.Close();

        Destroy(ThisObject);
        StopAllCoroutines();
    }
}
