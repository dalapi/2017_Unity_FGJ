using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandTutorial : MonoBehaviour {
	public float handSpeed = 5.0f;
	private float r;
	private float initialX;
	private float initialY;
	private float time;

	// Use this for initialization
	void Start () {
		initialX = this.GetComponent<Image>().rectTransform.anchoredPosition.x;
		initialY = this.GetComponent<Image>().rectTransform.anchoredPosition.y;
		time = 0.0f;
		r = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 deltaPos = 
		float targetX = initialX - (Mathf.Cos(time * handSpeed) / 2 + 0.5f) * r;
		float targetY = initialY + (Mathf.Cos(time * handSpeed) / 2 + 0.5f) * r;
		this.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(targetX, targetY);
		time += Time.deltaTime;
	}
}
