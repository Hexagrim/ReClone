using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator Anim;
    public Button[] buttons;
    void Start()
    {
        string[] values = { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10", "Level11", "Level12", "Level13", "Level14", "Level15", "Level16", "Level17", "Level18" };
        for (int i = 0; i < buttons.Length; i++)
        {
            string value = values[i];
            buttons[i].onClick.AddListener(() => Play(value));
        }
    }
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play(string lvl)
    {
        StartCoroutine(Transition(lvl));
    }

    IEnumerator Transition(string lvlName)
    {
        Anim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync(lvlName);
    }
}
