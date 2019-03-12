using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public float nextFire = 0.00F;
    public float fireRate = 0.01F; // szybkosc strzału
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("FireR") || Input.GetButtonDown("FireL") || Input.GetButtonDown("FireD") || Input.GetButtonDown("FireU") )&& Time.time>nextFire)
        {
            if (Input.GetAxisRaw("FireR") == 1f)
            {
                firePoint.transform.eulerAngles = new Vector3(0f, 0f, 0f);

            }
            else if (Input.GetAxisRaw("FireL") == 1f)
            {
                firePoint.transform.eulerAngles = new Vector3(0f, 180f, 0f);

            }
            else if (Input.GetAxisRaw("FireU") == 1f)
            {
                firePoint.transform.eulerAngles = new Vector3(0f, 0f, 90f);
            }
            else if (Input.GetAxisRaw("FireD") == 1f)
            {
                firePoint.transform.eulerAngles = new Vector3(0f, 0f, 270f);
            }


            nextFire = Time.time + fireRate;
            Shoot();
        }
	}
  void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("shooting", false);
    }
}
