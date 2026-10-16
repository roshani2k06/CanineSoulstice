using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public float breakDelay = 1f; // Time before the platform breaks
    

    private bool isBreaking = false;
    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = transform.position; // Save the original position for respawning
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBreaking)
        {
            isBreaking = true;
            Invoke("BreakPlatform", breakDelay); // Trigger break after delay
        }
    }

    void BreakPlatform()
    {
        // Disable the collider and renderer to make it disappear
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        
    }

    void RespawnPlatform()
    {
        // Re-enable the collider and renderer
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

        // Reset position
        transform.position = originalPosition;
        isBreaking = false;
    }
}
