using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public CinemachineVirtualCamera virtualCamera;
    public float defaultZoom = 10f;
    public float zoomSmoothTime = 0.3f;

    private float targetZoom;
    private float zoomVelocity;
    private bool isFixedCamera = false;
    private Transform fixedCamTarget;
    private Transform player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetZoom = defaultZoom;
        virtualCamera.Follow = player;
    }

    private void Update()
    {
        // Smooth zoom
        virtualCamera.m_Lens.OrthographicSize = Mathf.SmoothDamp(
            virtualCamera.m_Lens.OrthographicSize,
            targetZoom,
            ref zoomVelocity,
            zoomSmoothTime
        );

        // Handle fixed camera position
        if (isFixedCamera && fixedCamTarget != null)
        {
            virtualCamera.transform.position = new Vector3(
                fixedCamTarget.position.x,
                fixedCamTarget.position.y,
                virtualCamera.transform.position.z
            );
        }
    }

    public void SetCameraZone(CameraZone zone)
    {
        targetZoom = zone.zoomSize;

        if (zone.lockCamera && zone.fixedCameraPosition != null)
        {
            isFixedCamera = true;
            fixedCamTarget = zone.fixedCameraPosition;
            virtualCamera.Follow = null; // Disable follow
        }
    }

    public void ResetCamera()
    {
        targetZoom = defaultZoom;
        isFixedCamera = false;
        fixedCamTarget = null;
        virtualCamera.Follow = player;
    }
}



