using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultGameManager : MonoBehaviour {

	public GameObject[] star;
	public GameObject[] effect;
	//private GameObject newstar;
	private GameObject neweffect;
	private float maxWidth;
	private float maxHigth;
	private float time = 2;

	// Use this for initialization
	void Start () {
		maxWidth = 400.0f;
		maxHigth = 50.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		time -= Time.deltaTime;
		if (time < 0) {
			//random num 1.5f~2.0f
			time = Random.Range (1.5f, 2.5f);
			// random num for positionX
			float posX = 390 + Random.Range (-maxWidth, maxWidth);
			float posY = 410 + Random.Range (-maxHigth, maxHigth);
			//Vector3 starPosition = new Vector3 (posX, posY, 0);
			Vector3 effectPosition = new Vector3 (posX, posY, 0);
			//newstar = (GameObject)Instantiate (star [Random.Range (0, star.Length)], starPosition, Quaternion.identity);
			neweffect =(GameObject)Instantiate(effect [Random.Range (0, effect.Length)],effectPosition, Quaternion.identity);
			Destroy (neweffect, 4);
			//Destroy (newstar, 8);
		}
	}
}
