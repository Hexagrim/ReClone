using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    public TMP_Text maxClonesText;
    public GameObject clonePrefab;
    public Vector2 spawnPoint;
    private void Start()
    {
        spawnPoint = transform.position;
    }

    //super simple code lmao
    void Update()
    {
        maxClonesText.text = (GetComponent<PlayerCloneScript>().maxClone - GetComponent<PlayerCloneScript>().numOfClone).ToString();
        if (GetComponent<PlayerCloneScript>().maxClone <= GetComponent<PlayerCloneScript>().numOfClone) return;

        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.position = spawnPoint;
            FindFirstObjectByType<AudioManager>().PlaySFX(FindFirstObjectByType<AudioManager>().clone);
            FindFirstObjectByType<ResetRigidBodies>().ResetAll();
            GameObject clone = Instantiate(clonePrefab, spawnPoint, Quaternion.identity);
            var data = GetComponent<PlayerCloneScript>().GetRecording();
            data.Add(new PlayerInputFrame(false, false, false));
            clone.GetComponent<PlayerCloneScript>().StartReplay(data);
            GetComponent<PlayerCloneScript>().ResetRecording();
            GetComponent<PlayerCloneScript>().numOfClone++;
        }
    }
}
