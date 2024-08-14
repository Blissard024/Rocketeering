
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
 
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip success; 
    [SerializeField] AudioClip defeat; 
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        audioSource.PlayOneShot(defeat);
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
