using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
   public void GamePlay()
    {
        
        string path = Application.persistentDataPath + PlayerPrefs.GetString("username") + ".save";
        File.Delete(path);
       
    }

}
   
