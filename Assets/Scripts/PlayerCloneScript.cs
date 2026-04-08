using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerInputFrame
{
    public bool left;
    public bool right;
    public bool jump;

    public PlayerInputFrame(bool l, bool r, bool j)
    {
        left = l;
        right = r;
        jump = j;
    }
}

public class PlayerCloneScript: MonoBehaviour
{
    public bool isClone = false;

    private List<PlayerInputFrame> recordedInputs = new List<PlayerInputFrame>();
    private int replayIndex = 0;
    private bool isReplaying = false;
    public bool inputLeft;
    public bool inputRight;
    public bool inputJump;
    private bool jumpBuffered;

    void Update()
    {

        if (!isClone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpBuffered = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isClone)
        {
            HandleCloneReplay();
        }
        else
        {
            HandleRecord();
        }
    }

    void HandleRecord()
    {
        inputLeft = Input.GetKey(KeyCode.A);
        inputRight = Input.GetKey(KeyCode.D);
        inputJump = jumpBuffered;
        recordedInputs.Add(new PlayerInputFrame(inputLeft, inputRight, inputJump));
        jumpBuffered = false;
    }

    void HandleCloneReplay()
    {
        if (!isReplaying || replayIndex >= recordedInputs.Count) return;
        PlayerInputFrame frame = recordedInputs[replayIndex];
        inputLeft = frame.left;
        inputRight = frame.right;
        inputJump = frame.jump;

        replayIndex++;
    }

    public void StartReplay(List<PlayerInputFrame> data)
    {
        recordedInputs = new List<PlayerInputFrame>(data);
        replayIndex = 0;
        isReplaying = true;
    }
    public List<PlayerInputFrame> GetRecording() => recordedInputs;
}