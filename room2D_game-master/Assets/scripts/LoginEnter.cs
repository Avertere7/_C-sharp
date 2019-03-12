using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginEnter : MonoBehaviour {

    public string Username;
    public GameObject name1;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("score",0);
    }
	
	// Update is called once per frame
	void Update () {
        Username = name1.GetComponent<InputField>().text;
	}
    public void GamePlay()
    {
        PlayerPrefs.SetString("username", Username);
        SceneManager.LoadScene("menu");
    }
}
