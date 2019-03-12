using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class hp : MonoBehaviour
{
    public Sprite hp1;
    public Sprite hp2;
    public Image serce;
    public int zycie;


   
    void Start()
    { serce.sprite = hp1; }

    void Update()
    {
        Hero hero = FindObjectOfType<Hero>();
        if (hero.health >= zycie)
        {
            serce.sprite = hp1;
        }
        else if(hero.health < zycie)
        {
            serce.sprite = hp2;
        }
    }


   
}
