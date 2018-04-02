using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBreaker : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Garbage")
		{
			Destroy (other.GetComponent<CircleCollider2D> ().sharedMaterial);

		}
	}
}
