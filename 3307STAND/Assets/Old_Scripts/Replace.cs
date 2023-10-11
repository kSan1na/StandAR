using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : MonoBehaviour
{
    private GameObject Stand;
    public float invoke_time;
    private Rigidbody rb;
    void Start()
    {
        Stand = GameObject.Find("unitystend");
        rb = Stand.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Invoke("replace", invoke_time);
    }

    
    public void replace()
    {
        Stand = GameObject.Find("unitystend");
        rb=Stand.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
