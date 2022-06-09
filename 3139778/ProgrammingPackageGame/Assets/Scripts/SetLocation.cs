using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocation : MonoBehaviour
{
    private GameManager gameManager;
    private bool onSurface = false;

    [SerializeField] bool isCoin;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        if (isCoin)
        {
            gameManager.coinsLeft ++;
        }

        transform.position = new Vector3(Random.Range(-30f, 30f), 3.462f, Random.Range(-30f, 30f));

        StartCoroutine(CheckOnSurface());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("roof"))
        {
            onSurface = true;
        }
    }

    public IEnumerator CheckOnSurface()
    {
        yield return new WaitForSeconds(0.5f);

        if (!onSurface)
        {
            if (isCoin)
            {
                gameManager.coinsLeft--;
            }

            Destroy(this.gameObject);
        }
    }
}
