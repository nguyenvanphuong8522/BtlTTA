using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoRotate : MonoBehaviour
{
    private Rigidbody rb;
    [Range(0f, 100f)]
    public float force;
    private bool turnOn = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }
    public void TurnOn()
    {
        turnOn = !turnOn;
    }
    private void FixedUpdate()
    {
        if (turnOn)
        {
            rb.AddTorque(Vector3.up * force);
        }
    }
}
