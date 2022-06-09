using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverlaps : MonoBehaviour
{
    [SerializeField] private GameObject fillerPiece;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dungeonPiece")
        {
            Destroy(other.gameObject);
            Instantiate(fillerPiece, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
