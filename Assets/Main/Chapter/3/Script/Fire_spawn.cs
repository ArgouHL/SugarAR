using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_spawn : MonoBehaviour
{
	public ParticleSystem FireFlies;
	public ParticleSystem FireTorc;

	public void PlayFireObjects()
	{
		FireFlies.Play();
		FireTorc.Play();
	}
	public void StopFireObjects()
	{
		FireFlies.Stop();
		FireTorc.Stop();
	}
}
