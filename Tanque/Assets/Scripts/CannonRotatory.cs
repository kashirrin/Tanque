using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotatory : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float rotateSpeed = 20f;
    [SerializeField] GameObject[] bullets;
    [SerializeField] AudioClip cannon;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        CannonRotation();   
        ProcessFiring();
    }

    void CannonRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Rotation(-rotateSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Rotation(rotateSpeed);
        }
    }

    void Rotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.up * rotation * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActivateBullet(true);
        }
        else
        {
            SetActivateBullet(false);
        }
    }

    void SetActivateBullet(bool state)
    {
        foreach (GameObject bullet in bullets)
        {
            var emissionModule = bullet.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }
}
