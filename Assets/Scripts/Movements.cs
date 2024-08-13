using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Steering left");
            ApplyRotation(rotationThrust);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Steering Right");
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThrust)
    {
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed - Thrusting");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        } 

       


    }
}
