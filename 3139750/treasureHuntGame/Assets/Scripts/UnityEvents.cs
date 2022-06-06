using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvents : MonoBehaviour
{
    [System.Serializable]
    public class ObjectGrabbedEvent : UnityEvent<GameObject> { }

    [System.Serializable]
    public class ObjectDroppedEvent : UnityEvent<GameObject> { }
}