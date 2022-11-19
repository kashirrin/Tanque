using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank1Move : MonoBehaviour
{
    Rigidbody rb;
    AudioSource aus;
    [SerializeField] float moveSpeed = 150f;
    [SerializeField] float rotateSpeed = 150f;
    [SerializeField] AudioClip TankAdvance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer();
    }
    // Función de movimiento del vehiculo
    void MovePlayer(){

        if (Input.GetKey(KeyCode.W))
        {
            // la propiedad Translate sirve para moverte dependiendo los ejes seleccionados, en este caso forward que utiliza el eje Z
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (!aus.isPlaying)
            {
                aus.PlayOneShot(TankAdvance);
            }
        }
        else
        {
            aus.Stop();
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            if (!aus.isPlaying)
            {
                aus.PlayOneShot(TankAdvance);
            }
            else
            {
                aus.Stop();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rotation(-rotateSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Rotation(rotateSpeed);
        }
        /*
        float zValue = (Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed;
        float xValue = (Input.GetAxis("Horizontal")) * Time.deltaTime * rotateSpeed;
        transform.Translate(0,0,zValue);
        transform.Rotate(0,xValue,0);
        */
    }

    void Rotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.up * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
