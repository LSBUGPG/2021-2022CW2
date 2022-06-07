using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FPPlayerCamCtrl : MonoBehaviour
{
    public Transform camTarget;
    public CinemachineVirtualCamera CMCam;
    [SerializeField] float topClamp = 70;
    [SerializeField] float bottomClamp = 70;
    public bool lockCamera = false;

    FPPlayerInput _input;

    float cameraYaw;
    float cameraPitch;
    const float inputThreshold = 0.01f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _input = GetComponent<FPPlayerInput>();
    }
    void Update()
    {
        RotateCamera();
    }
    void RotateCamera()
    {
        if (_input.lookDir.sqrMagnitude >= inputThreshold && !lockCamera)
        {
            cameraYaw += _input.lookDir.x * Time.deltaTime;
            cameraPitch += _input.lookDir.y * Time.deltaTime;
        }
        cameraYaw = ClampAngle(cameraYaw, float.MinValue, float.MaxValue);
        cameraPitch = ClampAngle(cameraPitch, -topClamp, bottomClamp);

        camTarget.transform.localRotation = Quaternion.Euler(cameraPitch, camTarget.transform.rotation.y, camTarget.transform.rotation.z);
        rb.rotation = Quaternion.Euler(rb.rotation.x, cameraYaw, rb.rotation.z);
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
