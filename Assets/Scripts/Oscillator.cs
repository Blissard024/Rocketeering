using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;

    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        float tau = 2 * Mathf.PI;

        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1) *2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
