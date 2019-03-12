using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public string level;
    public int health;
    public float[] position;
    public int score;
    public bool[] levels = new bool[50];//liczba lvl


    public PlayerData(Hero player)
    {
        level = player.actual_lvl;
        health = player.health;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        score = player.score;
        levels = player.levels;
    }
}
