using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] AudioClip thrustSFX;
    [SerializeField] ParticleSystem thrusterParticle;
    [SerializeField] ParticleSystem leftRotateParticle;
    [SerializeField] ParticleSystem rightRotateParticle;
    [SerializeField] float thrustSpeed = 1000;
    [SerializeField] float rotationSpeed = 200;
    Rigidbody rb;
    AudioSource audioSource;
    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        ThrustProcess();
        RotationProcess();
    }
    private void ThrustProcess()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.fixedDeltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustSFX);
            }
            
            if (!thrusterParticle.isPlaying)
            {
                thrusterParticle.Play();
            }
        }
        else
        {
            audioSource.Stop();
            thrusterParticle.Stop();
        }
            
    }
    private void RotationProcess()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            StartRotation(rotationSpeed);
            rightRotateParticle.Play();
        }
        else if (rotationInput > 0)
        {
            StartRotation(-rotationSpeed);
            leftRotateParticle.Play();
        }
        else
        {
            leftRotateParticle.Stop();
            rightRotateParticle.Stop();
        }
    }

    private void StartRotation(float rotateRocket)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateRocket * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }

}
