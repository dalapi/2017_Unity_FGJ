using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCharacter : MonoBehaviour {

	public const int move = 50;


	public bool crowd;
	public bool rightSide;	//帰るときはどちら方向に行くか


	public int t = 0;					//0なら画面外、moveなら画面内に待機
	public Vector3 pos;				//待機ポジション
	void Start () {
		
	}
	

	void Update () {

		if (crowd)
		{
			if (t < move) 
			{
				if (rightSide) 
				{
					transform.position = Vector3.Lerp (new Vector3 (10.0f, transform.position.y, transform.position.z), pos, (float)t / (float)move);
				} 
				else 
				{
					transform.position = Vector3.Lerp (new Vector3 (-10.0f, transform.position.y, transform.position.z), pos, (float)t / (float)move);
				}
				t++;
			}
		}
		if (!crowd)
		{
			if (t > 0) 
			{
				if (rightSide) 
				{
					transform.position = Vector3.Lerp (new Vector3 (10.0f, transform.position.y, transform.position.z), pos, (float)t / (float)move);
				} 
				else 
				{
					transform.position = Vector3.Lerp (new Vector3 (-10.0f, transform.position.y, transform.position.z), pos, (float)t / (float)move);
				}
				t--;
			}
		}


	}
}
