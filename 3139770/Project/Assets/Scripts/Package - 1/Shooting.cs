using UnityEngine;

public class Shooting : MonoBehaviour
{


	public float damage = 10f;
	public float range = 100f;
	public Camera fpsCam;
	public ParticleSystem muzzelFlash;
	public GameObject impactEffect;
	public float impactForce = 30f;
	private bool paused = false;
	//update is called once per frame
	void Update()
	{
        if (paused)
        {
			return;
        }
		if (Input.GetButtonDown("Fire1"))
		{

			Shoot();

		}
	}

	public void SetPaused(bool pausedStatus)
	{
		paused = pausedStatus;
	}

	void Shoot()
	{
		muzzelFlash.Play();
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{

			Target target = hit.transform.GetComponent<Target>();
			if (target != null)
			{
				target.TakeDamage(damage);
			}
			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}
			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 0.1f);


			Target2 target2 = hit.transform.GetComponent<Target2>();
			if (target2 != null)
			{
				target2.TakeDamage(damage);
			}
			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}
			GameObject impactGO2 = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO2, 0.1f);
		}
	}
}
