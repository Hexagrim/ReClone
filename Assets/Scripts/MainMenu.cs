using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator Anim;
    public Button[] buttons;
    int maxLvls;
    void Start()
    {
        maxLvls = PlayerPrefs.GetInt("maxLvl", 0);

        string[] values = { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10", "Level11", "Level12", "Level13", "Level14", "Level15", "Level16", "Level17", "Level18" };
        for (int i = 0; i < buttons.Length; i++)
        {
            string value = values[i];
            buttons[i].onClick.AddListener(() => Play(value));
        }

        if (maxLvls != buttons.Length)
        {
            for (int i = maxLvls + 1; i < buttons.Length; i++)
            {
                buttons[i].enabled = false;
            }
            if (maxLvls != 0)
            {
                for (int i = maxLvls - 1; i > -1; i--)
                {
                    buttons[i].GetComponentInChildren<TMP_Text>().text = "<u>" + (i + 1) + "</u>";
                }
            }
        }
        else
        {

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
