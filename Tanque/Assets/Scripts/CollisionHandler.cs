using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoad;

    bool isTransitioning = false;
    bool disableColission = false;

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

    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Tank1Move>().enabled = false;
        Invoke("ReloadLevel", delayLoad);
    }

    void FinishSequence()
    {
        isTransitioning = true;
        GetComponent<Tank1Move>().enabled = false;
        Invoke("NextLevel", delayLoad);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
