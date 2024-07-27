using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_spawn : MonoBehaviour
{
    public static Smoke_spawn instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
	public GameObject Smoke;

	public GameObject barrel;

	public GameObject SmokeContainer;



	private Vector3 SmokePos = new Vector3(0, -0.811f, 0);
	public void SpawnSmoke()
	{
		// 生成烟雾对象
		SmokeContainer = Instantiate(Smoke, SmokePos, Quaternion.identity);

		// 将烟雾对象设为barrel的子物件
		SmokeContainer.transform.SetParent(barrel.transform);

		// 将烟雾对象的位置设为局部位置SmokePos
		SmokeContainer.transform.localPosition = SmokePos;
	}


	public void ClearSmokeObjects()
	{
		if (SmokeContainer != null)
		{
			Destroy(SmokeContainer);
		}

	}
}
