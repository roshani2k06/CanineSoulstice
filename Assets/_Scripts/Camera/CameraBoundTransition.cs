using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBoundTransition : MonoBehaviour
{
    public string nextSceneName; // Set the next scene name in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera")) // Check if the camera enters the boundary
        {
            SceneManager.LoadScene(nextSceneName); // Load the next scene
        }
    }
}

