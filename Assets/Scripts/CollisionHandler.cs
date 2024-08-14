
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Launching Pad":
                Debug.Log("This thing is friendly");
                break;

            case "Landing Pad":
                LoadNextLevel();
                Debug.Log("Congrats!");
                break;

            case "Fuel":
                Debug.Log("You picked up fuel!");
                break;

            default:
                Debug.Log("Sorry you blew up!");
                ReloadLevel();
                break;

        } 
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
