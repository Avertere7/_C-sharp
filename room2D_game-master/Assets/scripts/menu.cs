using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("room1_1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}    