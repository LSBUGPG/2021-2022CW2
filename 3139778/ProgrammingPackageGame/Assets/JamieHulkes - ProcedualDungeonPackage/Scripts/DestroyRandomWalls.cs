using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRandomWalls : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroyWalls());
    }

    IEnumerator destroyWalls()
    {
        yield return new WaitForSeconds(1);
        
        bool wallDestroy = (Random.value > 0.99f);

        if (wallDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
