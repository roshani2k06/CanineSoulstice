using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public float zoomSize = 10f;
    public bool lockCamera = false;
    public Transform fixedCameraPosition; // Used when lockCamera = true

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.Instance.SetCameraZone(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.Instance.ResetCamera();
        }
    }
}






