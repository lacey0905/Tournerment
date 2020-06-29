using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

	public GameObject HitPoints;
	public GameObject slash;
    public float radius;

	bool isOnHit = false;

	public BoxCollider col;

	private void Awake()
	{
		col = GetComponent<BoxCollider>();
		col.enabled = false;
	}

	private void FixedUpdate()
    {
		
	}

	public void HitOn()
	{
		col.enabled = true;
	}

	public void HitOut()
	{
		col.enabled = false;
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

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Test")
		{
			other.GetComponent<Enemy>().Damage(transform.position);
			//StartCoroutine(time());
		}
	}


}
