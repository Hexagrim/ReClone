using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator Anim;
    public GameObject ConnectedObj;

    public bool pressed;
    int pressedObjs;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }   

    void Update()
    {
        Anim.SetBool("pressed", pressed);
        if (ConnectedObj.GetComponent<DoorScript>())
        {
            ConnectedObj.GetComponent<DoorScript>().open = pressed;
        }
        if (ConnectedObj.GetComponent<PasWallScript>())
        {
            ConnectedObj.GetComponent<PasWallScript>().canPass = pressed;
        }


        if(pressedObjs <= 0)
        {
            pressedObjs = 0;
            pressed = false;
        }
        else
        {
            pressed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Clone"))
        {
            pressedObjs++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Clone"))
        {
            pressedObjs--;
        }
    }
}
