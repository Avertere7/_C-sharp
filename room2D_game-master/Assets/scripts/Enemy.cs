using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public int health = 100;
    public float speed; //predkosc 
    public int type = 2;
    public Rigidbody2D rb;
    public float range = 1;//range attaku (chodzi o melle kiedy złapie gracza domyslnie 1)
    public Animator animator;
    //1
    private Transform target; //cel  
    public float fireRate = 0.5F;
    private float nextAttack = 0.00F;
    //2
    private float oldPosition = 0.0f;
    public Vector2 pos1;
    public Vector2 pos2;

    //4

    public int TimeToExpolde = 4;
    public bool Set = false;
    
    //6
    private float latestDirectionChangeTime;
    private float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    
    /*
     *TYPY PRZECIWNIKÓW
     * 1 MELLE GONI GRACZA / 
     * 2 STRZELA RANDOMOWO OD PUNKTU A - B /
     * 3 CHODZI OD A-B - ZADAJE DMG KIEDY JESTES BLISKO /
     * 4 AHMET-WYBUCHA
     *  5 PROSZUJACY SIE WOLNO DO HEROSA I STRZELA 90 STOPNI 2 STRZALY
     * 6 RANDOMOWO CHODZACY I ZADAJE DMG KIEDY BLISKO /
     */
    void Start()
    {

        if (type == 1 || type == 4 || type == 5  )
        {
                 target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //ustaw cel
        }
        else if(type==2)
        {
            oldPosition = transform.position.x;
        }
        else if(type==3)
        {
            oldPosition = transform.position.x;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else if(type==6)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            latestDirectionChangeTime = 0f;
            calcuateNewMovementVector();
        }
    }
    void Update()
    {
        
        
            

        
        if (GameObject.FindGameObjectWithTag("Player") != null) 
         {
            if (type == 1)
            {
                UpdateType1();
            }
            else if (type == 2)
            {
                UpdateType2();
            }
            else if (type == 3)
            {
                UpdateType3();
            }
            else if (type == 4)
            {
                UpdateType4();
            }
            else if (type == 5)
            {
                UpdateType5();
            }
            else if (type == 6)
            {
                UpdateType6();
            }
        }
        else //koniec gry
         SceneManager.LoadScene("GameOver"); //zmienne zapisane w  PlayerPrefs.GetString("username"); <- nazwa gracza , score-> PlayerPrefs.GetInt("score") wyswietlenie  w nowej scenie (GameOver) i odnosnik do main menu 

    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("hit");
        health -= damage;
        animator.SetTrigger("hit");
        if (health<=0)
        {
            target = null;
            FindObjectOfType<AudioManager>().Play("dead2");
            animator.SetTrigger("death");
            Die();

        }
        animator.SetTrigger("run");
    }
	void Die()
    {
        if (type == 4)
        {
            Destroy(gameObject,2);
        }else
            Destroy(gameObject);
    }
    private void UpdateType1()
    {
        animator.ResetTrigger("isAttack1");
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > range) //jezeli odleglosc jest wieksza od 1 to biegnij
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//biegnij
            }
            else// w przeciwnym wypadku zadaj dmg graczowi
            {
                if (Time.time > nextAttack)
                {

                    Hero gracz = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();

                
                        animator.SetTrigger("isAttack1");

                        gracz.TakeDamage(1);
                    
                    nextAttack = Time.time + fireRate;
                    animator.SetTrigger("run");
                   
                }
              
            }
        }
    }
    private void UpdateType2()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

        if (transform.position.x > oldPosition) // patrzy na prawo
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (transform.position.x < oldPosition) // patrzy na lewo
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        oldPosition = transform.position.x; // updejtuj starą pozycje zeby spr następną pozycje
    }
    private void UpdateType3()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

        if (transform.position.x > oldPosition) // patrzy na prawo
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (transform.position.x < oldPosition) // patrzy na lewo
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        oldPosition = transform.position.x; // updejtuj starą pozycje zeby spr następną pozycje
        
            if (Vector2.Distance(transform.position, target.position) <range) //zadaj dmg kiedy ustalona odleglosc
            {
            
                if (Time.time > nextAttack)
                {
                    Hero gracz = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
                    gracz.TakeDamage(1);
                    nextAttack = Time.time + fireRate;
                }
            }
        }
    }
    private void UpdateType4()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > range) //jezeli odleglosc jest wieksza od 1 to biegnij
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//biegnij
            }
            else
            {
                
                
                
                
                    if (Vector2.Distance(transform.position, target.position) <= range) //spr czy dalej w rangu
                    {
                        Hero gracz = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();

                        gracz.TakeDamage(2);
                    }
                    target = null;
                    animator.SetTrigger("death");
                    Die();
                
            }

        }

    }
    private void UpdateType5()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > range) //jezeli odleglosc jest wieksza od 1 to biegnij
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//biegnij
            }

        }
    }
    private void UpdateType6()
    {
        //jezeli okreslony czas upłynął updejtuj vektor
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            animator.SetTrigger("reset");
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //rusz enemy
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        if (Math.Abs(movementPerSecond.x) >= Math.Abs(movementPerSecond.y))
        {
            if (movementPerSecond.x > 0)
                animator.SetTrigger("runR");
            else
                animator.SetTrigger("runL");
        }
        else 
        {
            if (movementPerSecond.y > 0)
                animator.SetTrigger("runU");
            else
                animator.SetTrigger("runD");
        }
       
        if (Vector2.Distance(transform.position, target.position) < range) //zadaj dmg kiedy ustalona odleglosc
        {

            if (Time.time > nextAttack)
            {
                //animator.ResetTrigger("runU");
                //animator.ResetTrigger("runD");
                //animator.ResetTrigger("runR");
                //animator.ResetTrigger("runL");

                //if (Math.Abs(movementPerSecond.x) >= Math.Abs(movementPerSecond.y))
                //{
                //    if (movementPerSecond.x > 0)
                //        animator.SetTrigger("attackR");
                //    else
                //        animator.SetTrigger("attackL");
                //}
                //else
                //{
                //    if (movementPerSecond.y > 0)
                //        animator.SetTrigger("attackU");
                //    else
                //        animator.SetTrigger("attackD");
                //}
                //animator.ResetTrigger("attackU");
                //animator.ResetTrigger("attackD");
                //animator.ResetTrigger("attackL");
                //animator.ResetTrigger("attackR"); ??????????????
                Hero gracz = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
                gracz.TakeDamage(1);
                nextAttack = Time.time + fireRate;
                animator.SetTrigger("reset");
            }
         
        }
    }

    void calcuateNewMovementVector()
    {
        //tworz randmowy vektor 
        movementDirection = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)).normalized;//
       
        movementPerSecond = movementDirection * characterVelocity;
      
    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (type == 6)
        {
            if (collision.gameObject.name.Contains("sciana_ziel"))
            {

                movementDirection = new Vector2(-movementDirection.x, -movementDirection.y);
                movementPerSecond = movementDirection * 2;
                transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),//odbijanie od sciany
                 transform.position.y + (movementPerSecond.y * Time.deltaTime));
                if (Math.Abs(movementPerSecond.x) >= Math.Abs(movementPerSecond.y))
                {
                    if (movementPerSecond.x > 0)
                        animator.SetTrigger("runR");
                    else
                        animator.SetTrigger("runL");
                }
                else
                {
                    if (movementPerSecond.y > 0)
                        animator.SetTrigger("runU");
                    else
                        animator.SetTrigger("runD");
                }
            }
        }
       


    }
    
    IEnumerator WaitFor(float x)
    {
        yield return new WaitForSeconds(x);
    }


}
