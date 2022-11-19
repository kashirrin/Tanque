using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Se crean los objetos y variables
    [SerializeField] float delayLoad;

    bool isTransitioning = false; // Variable booleana que determinar� cuando hagas la transici�n, para freezear los controles.
    bool disableColission = false;

    // Funci�n que detecta cuando el objeto en cuesti�n, dependiendo de su tag, entrar� al switch.
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

    // funci�n que crear� la secuencia de choque
    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Tank1Move>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }
    // funci�n que crear� la secuencia de t�rmino
    void FinishSequence()
    {
        isTransitioning = true;
        GetComponent<Tank1Move>().enabled = false;
        Invoke("NextLevel", delayLoad);
    }
    // funci�n que crear� la secuencia de recarga del nivel
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
