using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator Anim;
    public GameObject ConnectedObj;

    public bool pressed;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Clone"))
        {
            pressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Clone"))
        {
            pressed = false;
        }
    }
}
