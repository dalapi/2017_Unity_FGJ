using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{

	public Sprite[] characterSprites;	//キャラクターのスプライト候補

	SpriteRenderer charaSprite;			//キャラクターのスプライト


	void Start () 
	{
		charaSprite = GetComponent<SpriteRenderer> ();
		charaSprite.sprite = characterSprites [Random.Range(0, characterSprites.Length)];
	}

	void Update ()
	{
		
	}
}
