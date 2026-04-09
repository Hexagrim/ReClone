using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator transitionAnim;
    public string NextLevel;

    bool changingScene = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changingScene = false;
    }
    void Update()
    {
        if (changingScene) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadScene("MainMenu"));
        }
    }

    public void NextLvl()
    {
        StartCoroutine(LoadScene(NextLevel));
    }

    IEnumerator LoadScene(string name)
    {
        FindFirstObjectByType<PlayerCloneScript>().enabled = false;
        FindFirstObjectByType<PlayerCloneScript>().gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        changingScene = true;
        transitionAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(name);
    }
}
