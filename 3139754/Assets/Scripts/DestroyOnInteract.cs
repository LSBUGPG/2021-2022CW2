using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    public CameraShake cameraShake;

    private const float maxRange = 100f;

    public void OnStartHover()
    {
        Debug.Log($"Ready to destroy { gameObject.name}");
    }
    public void OnInteract()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        Destroy(gameObject,0.2f);
        Debug.Log($"Target Destroyed");
        
    }

    public void OnEndHover()
    {
        Debug.Log($"No longer selected");
    }

}
