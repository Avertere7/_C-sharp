using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLvl : MonoBehaviour
{
    public Animator animator;
    public string lvlToLoad;
    

    public void Fadeout()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        string dieLvl=PlayerPrefs.GetString("DieLvl");
        if (dieLvl.Contains("room1"))
            lvlToLoad = "room1-1";
        else
            lvlToLoad = "2-1";
        Hero hero = GetComponent<Hero>();
        hero.health = 5;
        hero.score = 0;
        SceneManager.LoadScene(lvlToLoad);
    }

}
