using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] private Color ContactColor;
    private Color OriginalColor;
    private MeshRenderer mr;

    private void Start()
    {
       mr = GetComponent<MeshRenderer>();
        OriginalColor = mr.material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mr.material.color = ContactColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mr.material.color = OriginalColor;
        }
    }

}
