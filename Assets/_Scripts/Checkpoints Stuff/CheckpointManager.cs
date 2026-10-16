using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance; // Singleton instance

    private Vector2 lastCheckpointPos = Vector2.zero; // Last activated checkpoint position

    private void Awake()
    {
        // Make sure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes if needed
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }

    // Call this method to set a new checkpoint
    public void SetCheckpoint(Vector2 newCheckpointPos)
    {
        lastCheckpointPos = newCheckpointPos;
        Debug.Log("Checkpoint set at: " + newCheckpointPos);
    }

    // Call this to get the last checkpoint position
    public Vector2 GetLastCheckpoint()
    {
        return lastCheckpointPos;
    }
}


