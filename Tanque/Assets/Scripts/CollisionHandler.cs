using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Se crean los objetos y variables
    [SerializeField] float delayLoad;

    bool isTransitioning = false; // Variable booleana que determinará cuando hagas la transición, para freezear los controles.
    bool disableColission = false;

    // Función que detecta cuando el objeto en cuestión, dependiendo de su tag, entrará al switch.
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || disableColission) { return; }

        switch (other.gameObject.tag)
        {
            case "Finish":
                FinishSequence();
                break;
            case "Hit":
                CrashSequence();
                break;
        }
    }

    // función que creará la secuencia de choque
    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Tank1Move>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }
    // función que creará la secuencia de término
    void FinishSequence()
    {
        isTransitioning = true;
        GetComponent<Tank1Move>().enabled = false;
        Invoke("NextLevel", delayLoad);
    }
    // función que creará la secuencia de recarga del nivel
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
