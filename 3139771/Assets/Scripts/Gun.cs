
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform fpsCam;
    public GameObject Bullet;

    private GameObject NewBullet;
    private Rigidbody BulletRb;

    public float BulletForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            NewBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(fpsCam.forward));
            BulletRb = NewBullet.GetComponent<Rigidbody>();

            BulletRb.AddForce(BulletForce * fpsCam.forward, ForceMode.Impulse);
        }
    }


    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}