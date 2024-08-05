using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{

    Rigidbody rb;
   [SerializeField] float thrustForce;
    [SerializeField] float rotationSpeed;
    AudioSource thrustSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // caching a reference to component
        thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    /// <summary>
    /// This method is used to add force upwards to an object if the player presses space
    /// </summary>
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
            if (!thrustSound.isPlaying)
            {
                thrustSound.Play();

            }
        }
        else
        {
            thrustSound.Stop();
        }
    }
    /// <summary>
    /// This method is used to rotate the object left or right if the player input's A or D
    /// </summary>
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if ((Input.GetKey(KeyCode.D)))
        {
            ApplyRotation(-rotationSpeed);
        }
    }
    /// <summary>
    /// This method is used to apply the rotation to a specific object
    /// </summary>
    /// <param name="rotationThisFrame"></param>
    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system and take over
    }

    
}
