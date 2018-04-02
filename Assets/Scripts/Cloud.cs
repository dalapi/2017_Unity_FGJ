using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour 
{

	public float speed;	//雲の移動速度

	void Update ()
	{
		//x軸負の方向に等速移動し、ループさせる
		transform.position = new Vector3 (transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
		if (transform.position.x < -24.0f) 
		{
			transform.position = new Vector3 (24.0f, transform.position.y, transform.position.z);
		}
	}
}
