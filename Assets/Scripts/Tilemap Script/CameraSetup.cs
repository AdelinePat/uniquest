using Unity.Cinemachine;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    void Start()
    {
        var vcam = Object.FindFirstObjectByType<CinemachineCamera>();
        var player = Object.FindFirstObjectByType<Player>();
        if (vcam != null && player != null)
            vcam.Follow = player.transform;
    }
}