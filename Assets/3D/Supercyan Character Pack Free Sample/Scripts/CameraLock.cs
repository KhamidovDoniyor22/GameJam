using Cinemachine;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float fixedXPosition; 

    private void LateUpdate()
    {
        Vector3 cameraPosition = virtualCamera.transform.position;

        cameraPosition.x = fixedXPosition;

        virtualCamera.transform.position = cameraPosition;
    }
}
