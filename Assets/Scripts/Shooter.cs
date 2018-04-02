using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject gameController;
	public GameObject[] trash;
	public int powerMin = 100;
	public int powerMax = 200;

	public float interval = 1.5f;

	GameObject lastShoot;
	float waitTime;

	void Start () 
	{
		StartCoroutine (Shoot ());
	}

	IEnumerator Shoot()
	{
		//interval時間ごとに新しいゴミが投げられる
		while (true)
		{
			lastShoot = Instantiate 
				(
				trash [Random.Range (0, trash.Length)],
				transform.position,
				Quaternion.identity,
				transform
			);

			//右上の方向に力を加える
			lastShoot.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(powerMin,powerMax),Random.Range(powerMin,powerMax) + 100.0f));
			waitTime = interval + gameController.GetComponent<GameController> ().countDown * 0.03f;
			yield return new WaitForSeconds (waitTime);
		}
	}
}
