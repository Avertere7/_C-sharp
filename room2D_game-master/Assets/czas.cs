using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class czas : MonoBehaviour
{
    public int timeLeft = 60;
    public Text countdown;
    bool clear = false;
    int score;


    void Start()
    {
       
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Skalowanie czasu
    }

    void Update()
    {
        countdown.text = ("Czas:" + timeLeft); // co wypisujemy
        if(timeLeft == 0)
        {
            FindObjectOfType<Hero>().TakeDamage(10);
        }
        if (GameObject.FindWithTag("Enemy") == null)
        {
            Hero hero = FindObjectOfType<Hero>();

            clear = true;
            if (clear == true && hero.levels[SceneManager.GetActiveScene().buildIndex]==false)
           {
                hero.levels[SceneManager.GetActiveScene().buildIndex] = true;
                score = PlayerPrefs.GetInt("score") + timeLeft;
                PlayerPrefs.SetInt("score", score + 50);
                
                
            }
        }
    }
    
    IEnumerator LoseTime()
    {
        while (!clear)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

    }
}
