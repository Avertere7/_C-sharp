using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GetScore : MonoBehaviour
{
    public Text countdown;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("score");
        countdown.text = ("Punkty:" + score);
    }
}
