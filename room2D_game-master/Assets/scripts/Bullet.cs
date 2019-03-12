using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 40;
   // public GameObject inpactEffect;//efekt uderzenia bulletu
 
	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("fire");
        rb.velocity = transform.right * speed;
	}
    void OnTriggerEnter2D( Collider2D hitInfo)
    {
        //if (gameObject.name != "Hero")
        //{
        Enemy enemy = hitInfo.GetComponent<Enemy>();//wykryj czy bullet uderzyl jakis obiekt o klasie enemy
            if (enemy != null)//jezeli tak to zadaj dmg
            {
                enemy.TakeDamage(damage);
               // Instantiate(inpactEffect, transform.position, transform.rotation);//stworz animacje uderzenia
               Destroy(gameObject);
            }
            else if (hitInfo.name == "tlo")
                Destroy(gameObject, 1);
        //}

    }
	
	
}
