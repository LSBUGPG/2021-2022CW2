using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name=="Third Person Controller")
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
