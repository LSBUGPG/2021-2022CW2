using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBobbing : MonoBehaviour
{

    PlayerMovement PM;
    Rigidbody RB;

    [SerializeField] float ThresholdSpeed;
    [SerializeField] float Amplitude;
    [SerializeField] float Frequency;

    [SerializeField] Transform CameraPos;

    Vector3 StartPos;
    float timer;

    private void Start()
    {
        PM = GetComponent<PlayerMovement>();
        RB = GetComponent<Rigidbody>();

        StartPos = CameraPos.localPosition;
    }

    private void Update()
    {
        HeadBob();
    }

    void HeadBob()
    {
        if (PM.Grounded && RB.velocity.magnitude > ThresholdSpeed)
        {
            timer += Time.deltaTime * Frequency;

            CameraPos.localPosition = new Vector3(
                CameraPos.localPosition.x,
                StartPos.y + Mathf.Sin(timer) * Amplitude,
                CameraPos.localPosition.z);
        }
        else
            CameraPos.localPosition = Vector3.Lerp(CameraPos.localPosition, StartPos, Time.deltaTime);
    }

}
