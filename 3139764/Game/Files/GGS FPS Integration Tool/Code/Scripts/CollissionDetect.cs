using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionDetect : MonoBehaviour
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log($"{hit.gameObject.name}");
    }
}
