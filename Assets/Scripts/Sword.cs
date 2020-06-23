using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

	public GameObject HitPoints;
	public GameObject slash;
    public float radius;

	bool isOnHit = false;

    private void FixedUpdate()
    {
		
	}

	public void Hit()
	{
		RaycastHit[] hits = Physics.SphereCastAll(HitPoints.transform.position, radius, Vector3.up);

		foreach (RaycastHit hit in hits)
		{
			if(hit.transform.tag == "Test")
			{
				hit.transform.GetComponent<Enemy>().Damage(transform.position);
				StartCoroutine(time());
			}
			
		}
	}

	IEnumerator time()
	{
		Time.timeScale = 0.05f;
		yield return new WaitForSeconds(0.005f);
		Time.timeScale = 1f;
	}

	public void OnSlash(bool state)
	{
		slash.SetActive(state);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(HitPoints.transform.position, radius);
	}

}
