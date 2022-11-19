using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    // Se crean los objetos y variables
    MeshRenderer renderer;
    Rigidbody rigidBody; 
    [SerializeField] int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();
        renderer.enabled = false;
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Se asigna un contador, el cual determinará cuando deberá activar la gravedad del objeto asignado.
        if (Time.time < timer)
        {
            
        }else{        
            renderer.enabled = true;
            rigidBody.useGravity = true;   
        }       
    }
}
