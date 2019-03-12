using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Hero : MonoBehaviour {
    public int health = 5;
    public int score = 0;
    public bool[] levels = new bool[50];//liczba lvl na razie randomowa 14
    public string actual_lvl;
    private bool showMenu = false;
    public static Hero instance;


    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            health = data.health;
            levels = data.levels;
            actual_lvl = data.level;
            score = data.score;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

            transform.position = position;
        }
      
        Time.timeScale = 1; 

    }
    public void Update()
    {
        if (levels[SceneManager.GetActiveScene().buildIndex]) //jezeli level zostal wyczyszczony zniszcz kazdego enemy z sceny
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

            for (var i = 0; i < gameObjects.Length; i++)
                Destroy(gameObjects[i]);
        }
        actual_lvl = SceneManager.GetActiveScene().name;
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
          

            showMenu = true;
        }


        //spr czy istnieja wrogowie
        if (GameObject.FindWithTag("Enemy")==null)
        {
            score=PlayerPrefs.GetInt("score");
            
          
           // levels[SceneManager.GetActiveScene().buildIndex] = true;//ustaw true po indexie jezeli cztysty

        }

        if (SceneManager.GetActiveScene().name == "GameWin")
            Die();



    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Stop("room");
            FindObjectOfType<AudioManager>().Play("losse");

            Die();
        }
    }
    void Die()
    {
        PlayerPrefs.SetInt("score",score);//zapisz wynik przed smiercia
        PlayerPrefs.SetString("DieLvl", actual_lvl);
        Destroy(gameObject);
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

       

        health = data.health;
        levels = data.levels;
        actual_lvl = data.level;
        score = data.score;
        PlayerPrefs.SetInt("score",score);
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        SceneManager.LoadScene(data.level);
    }

    private void OnGUI()
    {
        if (showMenu == true)
        {
            if (GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-80, 100, 50), "Resume"))
            {
                showMenu = false;
                Time.timeScale = 1;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Exit"))
            {
                actual_lvl = SceneManager.GetActiveScene().name;
                SaveSystem.SavePlayer(this);
                Destroy(gameObject);
                SceneManager.LoadScene("menu");
            }
        }
    }
}
