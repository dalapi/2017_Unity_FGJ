using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

	public int speedMin = 220;
	public int speedMax = 260;

	public float speed = 1.0f;

	void Start ()
	{
		speed = (float)Random.Range (speedMin, speedMax) / 100.0f;
	}

	void Update ()
	{
		transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,transform.position.y,transform.position.z);
	}

}
