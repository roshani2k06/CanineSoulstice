using UnityEngine;

public class GoldenKeyWall : MonoBehaviour
{
    private bool isWallOpen = false;  // Track if the wall is open or not
    private BoxCollider2D wallCollider; // To disable collider when the wall opens

    private void Start()
    {
        // Get the BoxCollider2D on start (so we can disable it when the wall opens)
        wallCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with the wall and has the Golden Key
        if (!isWallOpen && collision.gameObject.CompareTag("Player") && SecretManager.Instance.HasGoldenKey())
        {
            OpenWall();
        }
    }

    private void OpenWall()
    {
        if (!isWallOpen)
        {
            isWallOpen = true;
            Debug.Log("Golden Key Wall Opened!");

            // Disable the wall's collider so the player can pass through
            wallCollider.enabled = false;

            // Optional: You could also animate the wall disappearing, moving, etc.
            // Destroy the wall after a short delay (if you want to add a delay)
            Destroy(gameObject); // Immediately destroys the wall after opening
        }
    }
}





