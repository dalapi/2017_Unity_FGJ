using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour 
{

	//トランポリンのx、y座標の最大、最小値
	public const float MinX = -7.5f;	
	public const float MaxX = 2.6f;
	public const float MinY = -4.0f;
	public const float MaxY = 3.0f;

	[Range(0.0f,300.0f)]
	public float resilienceY = 10.0f;	//上に弾く力
	public float resilienceX = 10.0f;	//横に弾く力
	public float speed = 0.2f;			//トランポリンの移動の速さ

	public AudioSource bound;

	Vector3 tempPosition;

	void Start()
	{
		bound = GetComponent<AudioSource> ();
	}

		void Update () 
	{
		//移動できる範囲を超えたら連れ戻す
		tempPosition = new Vector3(transform.position.x + Input.GetAxis ("Horizontal") * speed,transform.position.y/* + Input.GetAxis ("Vertical") * speed*/,transform.position.z);
		if (tempPosition.x > MaxX) 
		{
			tempPosition = new Vector3(MaxX,tempPosition.y,tempPosition.z);
		}
		if (tempPosition.x < MinX) 
		{
			tempPosition = new Vector3 (MinX, tempPosition.y, tempPosition.z);
		}

		if (tempPosition.y > MaxY)
		{
			tempPosition = new Vector3(tempPosition.x,MaxY,tempPosition.z);
		}
		if (tempPosition.y < MinY) 
		{
			tempPosition = new Vector3 (tempPosition.x, MinY, tempPosition.z);
		}

		transform.position = tempPosition;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		bound.Play ();
		if (other.transform.tag == "Garbage" /*&& Input.GetKey("space")*/) 
		{
			other.transform.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0.0f,resilienceY));
			//other.transform.GetComponent<Trash> ().speed = (other.transform.position.x - transform.position.x) * resilienceX ;
		}

	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.transform.tag == "Garbage" /*&& Input.GetKey("space")*/) 
		{
			other.transform.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0.0f,resilienceY));
		}
	}
}
