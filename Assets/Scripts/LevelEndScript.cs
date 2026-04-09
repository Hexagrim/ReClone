using UnityEngine;
using System.Collections;
public class LevelEndScript : MonoBehaviour
{
    public LevelManager LevelManager;
    public GameObject Player;

    bool ended;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ended) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            ended = true;
            FindFirstObjectByType<AudioManager>().PlaySFX(FindFirstObjectByType<AudioManager>().lvlEnd);
            LevelManager.NextLvl();
            StartCoroutine(LerpPosition(Player.transform.position,transform.position));

        }
    }
    IEnumerator LerpPosition(Vector3 start, Vector3 end)
    {
        float duration = 0.15f;
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            Player.transform.position = Vector3.Lerp(start, end, t);
            time += Time.deltaTime;
            yield return null;
        }
        Player.transform.position = end;
    }
}
