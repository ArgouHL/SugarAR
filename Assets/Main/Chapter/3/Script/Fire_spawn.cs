using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_spawn : MonoBehaviour
{
	public static Fire_spawn instance;
	void Awake()
	{
		if (instance == null)
		{
			instance = this;

		}
	}
	public GameObject FireFlies;
	public GameObject FireTorc;
	private GameObject FireFliesContainer;
	private GameObject FireTorcContainer;
	private Vector3 FliesPos = new Vector3(-0.22f, 0.19f, -1.7917f);

	private Vector3 FirePos = new Vector3(-0.22f, -0.921f, -1.56f);

	public IEnumerator SpawnObjects()
	{
		FireTorcContainer = Instantiate(FireTorc, FirePos, Quaternion.identity);
		yield return new WaitForSeconds(1);
		FireFliesContainer = Instantiate(FireFlies, FliesPos, Quaternion.identity);
	}
	public void ClearFireObjects()
	{

		if (FireFliesContainer != null)
		{
			Destroy(FireFliesContainer);
		}
		if (FireTorcContainer != null)
		{
			Destroy(FireTorcContainer);
		}
	}
}
