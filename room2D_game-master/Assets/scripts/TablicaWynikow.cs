using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TablicaWynikow : MonoBehaviour {

    public Text scoreText1;
    public Text scoreText2;
    public Text scoreText3;
    public Text name1;
    public Text name2;
    public Text name3;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("score")>PlayerPrefs.GetInt("1st"))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
            PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("1st"));
            PlayerPrefs.SetInt("1st", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
            PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
            PlayerPrefs.SetString("name1", PlayerPrefs.GetString("username"));
        }else
        if(PlayerPrefs.GetInt("score")<PlayerPrefs.GetInt("1st") && PlayerPrefs.GetInt("score")>PlayerPrefs.GetInt("2nd"))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
            PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
            PlayerPrefs.SetString("name2", PlayerPrefs.GetString("username"));
        }else 
        if (PlayerPrefs.GetInt("score") < PlayerPrefs.GetInt("2nd") && PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("3rd"))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("username"));
        }

        scoreText1.text = PlayerPrefs.GetInt("1st").ToString();
        scoreText2.text = PlayerPrefs.GetInt("2nd").ToString();
        scoreText3.text = PlayerPrefs.GetInt("3rd").ToString();
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("name1")))
            name1.text = "brak";
        else
            name1.text = PlayerPrefs.GetString("name1");

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("name2")))
            name2.text = "brak";
        else
            name2.text = PlayerPrefs.GetString("name2");

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("name3")))
            name3.text = "brak";
        else
            name3.text = PlayerPrefs.GetString("name3");
        if(PlayerPrefs.GetInt("3rd")==0)
          PlayerPrefs.SetInt("3rd", 0);
        if(PlayerPrefs.GetInt("2nd")==0)
             PlayerPrefs.SetInt("2nd", 0);
        if (PlayerPrefs.GetInt("1st") == 0)
            PlayerPrefs.SetInt("1st", 0);


    }
	

}
