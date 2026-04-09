using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator Anim;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void Quit()
    {
        Application.Quit();
    }

    void Play()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        Anim.SetTrigger("Levels");
    }
}
