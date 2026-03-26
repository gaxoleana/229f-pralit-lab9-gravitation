using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static List<Gravity> otherObj;
    private Rigidbody rb;
    const float G = 6.67f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObj == null )
        {
            otherObj = new List<Gravity>();
        }
        otherObj.Add(this);
    }

    void FixedUpdate()
    {
        foreach (Gravity obj in otherObj)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;

        float distance = direction.magnitude;
        if (distance == 0f) return;

        float forceMagnitude = G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);
        Vector3 gravityForce = forceMagnitude * direction.normalized;
        otherRb.AddForce(gravityForce);
    }
}
