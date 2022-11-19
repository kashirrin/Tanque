using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    // Función para asignar puntuación
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Hit")
        {
            hits += 1;
            Debug.Log("Puntuación: " + hits);    
        }       
    }
}
