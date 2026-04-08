using UnityEngine;
using System.Collections.Generic;

public class ResetRigidBodies : MonoBehaviour
{
    [System.Serializable]
    public class BodyData
    {
        public Rigidbody2D rb;
        public Vector3 originalPosition;
        public float originalRotation;
    }

    public List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();
    private List<BodyData> storedData = new List<BodyData>();

    void Start()
    {
        foreach (Rigidbody2D rb in rigidbodies)
        {
            storedData.Add(new BodyData
            {
                rb = rb,
                originalPosition = rb.position,
                originalRotation = rb.rotation
            });
        }
    }

    public void ResetAll()
    {
        foreach (var data in storedData)
        {
            Rigidbody2D rb = data.rb;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = 0;
            rb.position = data.originalPosition;
            rb.rotation = data.originalRotation;
            rb.WakeUp();
        }
    }
}
