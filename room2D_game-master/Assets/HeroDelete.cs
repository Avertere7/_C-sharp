using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDelete : MonoBehaviour
{
    public void DeleteHero ()
    {
        print("score:"+PlayerPrefs.GetInt("score"));
        PlayerPrefs.SetInt("score", 0);
        print("score:"+PlayerPrefs.GetInt("score"));
    }


}
