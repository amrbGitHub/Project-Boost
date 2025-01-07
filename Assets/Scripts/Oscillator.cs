using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 movementVector;
    float movementFactor;
    public float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; 

        // tau is 2 pi
        const float tau = Mathf.PI * 2; // 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1
        // because sin waves go from -1-1 we want the movement factor range to be from 0-1 so we +1f and then /2 (-1 + 1 = 0, 1+1 = 2) / 2 = 0,1
        movementFactor = (rawSinWave + 1f) / 2f; 


        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
