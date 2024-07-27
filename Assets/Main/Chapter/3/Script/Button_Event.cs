using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Event : MonoBehaviour
{
	public GameObject ResetRotetarget;
	public Quaternion originalRate;
	// Start is called before the first frame update

	public void ResetRote( )
	{
		ResetRotetarget.transform.rotation = originalRate;

	}
}
