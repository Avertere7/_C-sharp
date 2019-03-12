using UnityEngine.SceneManagement;
using UnityEngine;

public class LvlChanger : MonoBehaviour
{
    public Animator animator;
    public string lvlToLoad;
 
    public void Fadeout()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

}
