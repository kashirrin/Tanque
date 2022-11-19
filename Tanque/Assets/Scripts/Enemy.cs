using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Función que destruye el objeto al ser impactado por el proyectil.
    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{name} Hit by {other.gameObject.name}");
        Destroy(gameObject);
    }
}
