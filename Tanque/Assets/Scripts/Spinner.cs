using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField] float xVar;
    [SerializeField] float yVar;
    [SerializeField] float zVar;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xVar, yVar, zVar);
    }
}
