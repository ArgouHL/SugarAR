using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiling_spawn : MonoBehaviour
{
	public ParticleSystem Boiling;

	public void PlayBoilingObjects()
	{
		Boiling.Play();
	}
	public void StopBoilingObjects()
	{
		Boiling.Stop();
	}
}
