using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootE : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float nextFire = 0.00F;
    public string kierunek = "dol";
    public float fireRate = 0.01F; // szybkosc strzału
    public Enemy enemy;
    public Animator animator;

                                  
    void Start () {
    
            switch (kierunek)
            {
                case "dol":
                    firePoint.transform.eulerAngles = new Vector3(0f, 0f, 270f);
                    break;
                case "gora":
                    firePoint.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    break;
                case "prawo":
                    firePoint.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    break;
                case "lewo":
                    firePoint.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                    break;
                default://domyslnie strzelaj w dol
                    firePoint.transform.eulerAngles = new Vector3(0f, 0f, 270f);
                    break;

            }
        
    }

    void Update () {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
     
    }
    void Shoot()
    {
        if (enemy.type == 4)
        {
            

            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
        if(enemy.type==5)
        {
            animator.SetTrigger("attack");
            firePoint.transform.eulerAngles = new Vector3(0f, 0f, 300f);
            Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
            firePoint.transform.eulerAngles = new Vector3(0f, 0f, 210f);
            Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
            

            firePoint.transform.eulerAngles = new Vector3(0f, 0f, 390f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.transform.eulerAngles = new Vector3(0f, 0f, 480f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            animator.SetTrigger("run");
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }

        //Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
