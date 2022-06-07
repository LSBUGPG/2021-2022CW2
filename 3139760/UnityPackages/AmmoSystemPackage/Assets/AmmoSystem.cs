using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    [SerializeField]
    public int maxAmmo = 7;
    int ammoLeft;

    public Image prefab;
    public Transform panel;
    List<Image> bullets;

    public Sprite green;
    public Sprite red;

    void Start()
    {
        ammoLeft = maxAmmo;
        bullets = new List<Image>();
        for (int i = 0; i < maxAmmo; i++)
        {
            bullets.Add(Instantiate(prefab, panel));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentBullet = maxAmmo - ammoLeft;
            bullets[currentBullet].sprite = red;
            ammoLeft--;
        }

        if (ammoLeft <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < maxAmmo; i++)
        {
            bullets[i].sprite = green;
            ammoLeft = maxAmmo;
        }

        
    }
}
