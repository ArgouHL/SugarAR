using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_spawn : MonoBehaviour
{


	public ParticleSystem Smoke;
	public void SpawnSmoke()
	{
		Smoke.Play();
		// 生成烟雾对象
		//SmokeContainer = Instantiate(Smoke, SmokePos, Quaternion.identity);

		//// 将烟雾对象设为barrel的子物件
		//SmokeContainer.transform.SetParent(barrel.transform);

		//// 将烟雾对象的位置设为局部位置SmokePos
		//SmokeContainer.transform.localPosition = SmokePos;

	}


	public void ClearSmokeObjects()
	{
		Smoke.Stop();
	}
}
