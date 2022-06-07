using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraCtrl : MonoBehaviour
{
    [SerializeField] GameObject cinemachineCamTarget;
    [SerializeField] float topClamp = 70;
    [SerializeField] float bottomClamp = -30;
    public bool lockCamera = false;

    ThirdPersonInput tpInput;

    float cameraYaw;
    float cameraPitch;
    const float inputThreshold = 0.01f;
    private void Awake()
    {
        tpInput = GetComponent<ThirdPersonInput>();
    }
    void Update()
    {
        RotateCamera();
    }
    public void UnlockCursor(bool active)
    {
        lockCamera = active;
        Cursor.visible = active;
        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
    }
    void RotateCamera()
    {
        if(tpInput.LookDir().sqrMagnitude >= inputThreshold && !lockCamera)
        {
            cameraYaw += tpInput.LookDir().x * Time.deltaTime;
            cameraPitch += tpInput.LookDir().y * Time.deltaTime;
        }
        cameraYaw = ClampAngle(cameraYaw, float.MinValue, float.MaxValue);
        cameraPitch = ClampAngle(cameraPitch, bottomClamp, topClamp);

        cinemachineCamTarget.transform.rotation = Quaternion.Euler(cameraPitch, cameraYaw, 0);
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
