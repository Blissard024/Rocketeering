using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 10f;
    [SerializeField] AudioClip mainEngine; 
    [SerializeField] ParticleSystem mainEngineParticles; 
    [SerializeField] ParticleSystem leftEngineParticles; 
    [SerializeField] ParticleSystem rightEngineParticles; 
    AudioSource audioSource;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            ApplyRotation(rotationThrust);
            if (!rightEngineParticles.isPlaying) 
            {
                rightEngineParticles.Play();
            }
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if (!leftEngineParticles.isPlaying) 
            {
                leftEngineParticles.Play();
            }
                
        }





        
    }

    private void ApplyRotation(float rotationThrust)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing so the rotate system can take over
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
                mainEngineParticles.Play();
            } 
        } 

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            audioSource.Stop();
            mainEngineParticles.Stop();

        }  

    }
}
