using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallInOut : MonoBehaviour
{
	public MeshRenderer waterfallMaterial;
	public GameObject Waterfall;
	public GameObject WaterPlane;
	Animation anim;


	bool WaterIn = false;


	private void PlaywaterfallS5()
	{
		anim = Waterfall.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "waterfallS5");
	}
	public void WaterfallIn()
	{
		WaterIn = true;
		StartCoroutine(AnimateWaterfall(-1f, -0.6f, -1f, 0.6f, 0.5f));
		//print("play");
	}

	public void WaterfallOut()
	{
		WaterIn = false;
		StartCoroutine(AnimateWaterfall(-0.6f, 1f, 0.6f, 1f, 0.5f));
	}

	private IEnumerator AnimateWaterfall(float startLightLength, float endLightLength, float startLightLengthF, float endLightLengthF, float duration)
	{
		
		// 获取当前的材质实例
		Material mat = waterfallMaterial.material;

		// 记录初始时间
		float elapsedTime = 0f;

		// 动画循环
		while (elapsedTime < duration)
		{
			elapsedTime += Time.deltaTime;
			float t = Mathf.Clamp01(elapsedTime / duration);

			if (elapsedTime > 0.15f)
			{

				if (WaterIn == true)
				{

					anim = WaterPlane.GetComponent<Animation>();
					PlayAnim.instance.PlayAnimation(anim, "WaterPlaneS5");
				}
			}
			// 平滑插值
			float currentLightLength = Mathf.Lerp(startLightLength, endLightLength, t);
			float currentLightLengthF = Mathf.Lerp(startLightLengthF, endLightLengthF, t);

			// 设置材质属性
			mat.SetFloat("_lightLength", currentLightLength);
			mat.SetFloat("_lightLengthF", currentLightLengthF);

			// 等待下一帧
			yield return null;
		}

		// 确保动画结束时达到最终值
		mat.SetFloat("_lightLength", endLightLength);
		mat.SetFloat("_lightLengthF", endLightLengthF);
		
	}
}
