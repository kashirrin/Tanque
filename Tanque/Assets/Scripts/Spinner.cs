using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField] float xVar;
    [SerializeField] float yVar;
    [SerializeField] float zVar;
    // Update is called once per frame
    // Aquí simplemente se le da giro al objeto por medio de la propiedad transform con su componente Rotate.
    void Update()
    {
        transform.Rotate(xVar, yVar, zVar);
    }
}
