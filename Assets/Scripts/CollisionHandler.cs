
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Launching Pad":
                Debug.Log("This thing is friendly");
                break;

            case "Landing Pad":
                Debug.Log("Congrats!");
                break;

            case "Fuel":
                Debug.Log("You picked up fuel!");
                break;

            default:
                Debug.Log("Sorry you blew up!");
                break;

        } 
    }
}
