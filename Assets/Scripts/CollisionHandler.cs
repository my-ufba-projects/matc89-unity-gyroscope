using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that load scenes

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX Prefab on Player")] [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        //StartDeathSequence();
        //deathFX.SetActive(true);
        //Invoke("ReloadLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        print("You are dead");
        SendMessage("StartDying");
    }

    private void ReloadLevel() // string referenced
    {
        SceneManager.LoadScene(1);
    }

}
