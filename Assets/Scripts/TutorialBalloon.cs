using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBalloon : MonoBehaviour {
	public float balloonSpeed = 1.0f;
	private float x;
	private float y;
	private float xMin = -350.0f;
	private float xMax = 350.0f;
	private float yMax = 290.0f;
	private float canvasHeight;
	private float balloonHeight;
	// Use this for initialization
	void Start () {
		x = Random.Range(xMin, xMax);
		y = this.GetComponent<Image>().rectTransform.anchoredPosition.y;
		canvasHeight = 450.0f;
		balloonHeight = 110.0f;
	}
	
	// Update is called once per frame
	void Update () {
		y += balloonSpeed * Time.deltaTime;
		if (y > yMax)
		{
			x = Random.Range(xMin, xMax);
			y -= (canvasHeight + balloonHeight);
		}
		this.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(x, y);
	}
}
