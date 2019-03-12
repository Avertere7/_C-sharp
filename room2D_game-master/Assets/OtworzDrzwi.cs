using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtworzDrzwi : MonoBehaviour
{


    public Sprite OtwarteDrzwi;
    public Sprite OtwarteDrzwiL;
    public Sprite OtwarteDrzwiD;
    public Sprite OtwarteDrzwiR;
    public string loadLevel;
    public bool koniec = false;
    public Collider2D colider;
    float rot = 0;

    void Update()
    {
        rot = this.gameObject.transform.eulerAngles.z;
        if (GameObject.FindWithTag("Enemy") == null)
        {
           

            /* switch (rot)
             {
                 case 90:
                     OtwarteDrzwi = OtwarteDrzwiL;
                     break;
                 case 180:
                     OtwarteDrzwi = OtwarteDrzwiD;
                     break;
                 case 270:
                     OtwarteDrzwi = OtwarteDrzwiR;
                     break;
             } */

            if (koniec == false)
            {
                colider.isTrigger = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = OtwarteDrzwi;
                FindObjectOfType<AudioManager>().Play("win");
                koniec = true;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            if (other.gameObject.tag == "Player")
            {
                //180 -D | 0 U | L  90 | p
                if (rot == 180)
                    other.transform.position = new Vector3(0,2.5f, 0);
                else if (rot == 0)
                    other.transform.position = new Vector3(0,-1.5f, 0);
                else if (rot == 90)
                    other.transform.position = new Vector3(4, 1, 0);
                else if (rot == 270)
                    other.transform.position = new Vector3(-4, 1, 0);


                SceneManager.LoadScene(loadLevel);
            }
        }

    }
}
