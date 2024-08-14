
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
 
    [SerializeField] float levelLoadDelay = 1f;
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Launching Pad":
                Debug.Log("This thing is friendly");
                break;

            case "Landing Pad":
                StartSuccessSequence();
                Debug.Log("Congrats!");
                break;

            default:
                Debug.Log("Sorry you blew up!");
                StartCrashSequence();
                break;

        } 
    }

    private void StartSuccessSequence()
    {
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
