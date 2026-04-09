using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator Anim;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        StartCoroutine(Transition("Level1"));
    }

    IEnumerator Transition(string lvlName)
    {
        Anim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync(lvlName);
    }
}
