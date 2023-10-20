using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearPush : MonoBehaviour
{
    Rigidbody rb;

    public float tearSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb= gameObject.GetComponent<Rigidbody>();

        rb.AddForce(rb.transform.forward * tearSpeed);
    }
}
