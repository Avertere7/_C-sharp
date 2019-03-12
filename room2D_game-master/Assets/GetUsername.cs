using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUsername : MonoBehaviour
{
    public Text username;
    public Text score;

    void Start()
    {
        username.text = (PlayerPrefs.GetString("username"));
        score.text = ("Wynik: "+PlayerPrefs.GetInt("score"));

    }

}
