using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip jump, clone, lvlEnd;
    public AudioSource Sfx;
    public bool canPlaySfx;
    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (GetComponent<AudioSource>() != null)
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                GetComponent<AudioSource>().volume = 0.05f;
            }
            else
            {
                GetComponent<AudioSource>().volume = 0.01f;
            }
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        Sfx.pitch = Random.Range(0.8f, 1.2f);
        Sfx.PlayOneShot(sfx);
    }

}
