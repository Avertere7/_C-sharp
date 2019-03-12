using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Stop("Menu");
        FindObjectOfType<AudioManager>().Play("room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
