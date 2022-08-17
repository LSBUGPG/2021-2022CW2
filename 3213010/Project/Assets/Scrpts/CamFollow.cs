using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform CamTarget;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = CamTarget.position;
    }
}
