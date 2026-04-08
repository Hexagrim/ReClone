using UnityEngine;

public class PasWallScript : MonoBehaviour
{
    private Animator Anim;
    public bool canPass;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("canPass", canPass);
    }

}
