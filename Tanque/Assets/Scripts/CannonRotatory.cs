using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotatory : MonoBehaviour
{
    // Se crean los objetos y variables utilizadas para el cañón
    Rigidbody rb; // Se crea objeto de la clase Rigidbody
    [SerializeField] float rotateSpeed = 20f; // Variable serializada que determinará a velocidad de giro del cañón
    [SerializeField] GameObject[] bullets; // Se crea el objeto bullet para utilizar las particulas que se sarán como proyectil
    [SerializeField] AudioClip cannon; // objeto de tipo audioclip para el sonido del disparo

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Se inicializa el objeto rb.
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        CannonRotation();   
        ProcessFiring();
    }

    // Función que detecta la entrada del teclado para girar el cañón
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

    // Función que girará el ca{on dependiendo del parámetro (velocidad de giro) ingresado.
    void Rotation(float rotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.up * rotation * Time.deltaTime); // se utiliza el componente up de la clase Vector3, este hace referencia al eje Y, por lo que solo girará en ese eje
        rb.freezeRotation = false;
    }

    // función que procesara cuando debe disparar el cañón
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

    // función que creará la particula, en este caso, el proyectil.
    void SetActivateBullet(bool state)
    {
        foreach (GameObject bullet in bullets)
        {
            var emissionModule = bullet.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }
}
