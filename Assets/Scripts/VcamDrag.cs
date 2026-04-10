using UnityEngine;
using Unity.Cinemachine;
public class VcamDrag : MonoBehaviour
{
    public float dragSpeed = 0.01f;
    public float returnSpeed = 0.5f;

    private CinemachineCamera vcam;

    private Transform originalFollow;

    private bool isDragging = false;
    private bool isReturning = false;

    private Vector3 lastMousePos;

    void Start()
    {
        vcam = GetComponent<CinemachineCamera>();

        if (vcam != null)
        {
            originalFollow = vcam.Follow;
        }
    }

    void Update()
    {
        if (vcam == null) return;
        HandleInput();
        if (isDragging) HandleDrag();
        if (isReturning) SmoothReattach();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            isReturning = false;
            lastMousePos = Input.mousePosition;
            vcam.Follow = null;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            isReturning = true;
        }
    }

    void HandleDrag()
    {
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 move = new Vector3(-delta.x, -delta.y, 0) * dragSpeed;
        transform.Translate(move, Space.Self);
        lastMousePos = Input.mousePosition;
    }

    void SmoothReattach()
    {
        vcam.Follow = originalFollow;
        Vector3 targetPos = transform.position;
        returnSpeed -= Time.deltaTime * 5f;

        if (returnSpeed <= 0f)
        {
            isReturning = false;
            returnSpeed = 0.05f;
        }
    }
}

