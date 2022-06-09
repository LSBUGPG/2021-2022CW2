using UnityEngine;


public class Target2 : MonoBehaviour
{
	public float health = 50f;
	KillCounter killCounterScript;

	private void Start()
	{
		killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0f)
		{
			Die();
		}
	}

	void Die()
	{
		killCounterScript.RemoveKill();
		Destroy(gameObject);
	}
}