using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        // Switch to 640 x 480 full-screen at 60 hz
        Screen.SetResolution(1024, 768, true, 60);
    }
}