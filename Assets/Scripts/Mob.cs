using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour 
{
	public int mobNum;
	public GameObject comboCheck;
	public GameObject original;
	GameObject clone;

	[SerializeField]
	GameObject[] mobs;
	[SerializeField]
	Sprite[] mobSprite;

	void Start ()
	{
		original = transform.Find ("mobOriginal").gameObject;
		for (int i = 0; i < mobs.Length; i++)
		{
			if (Random.value < 0.5f)
			{

				mobs [i] = Instantiate (
					original,
					new Vector3 (10.0f,original.transform.position.y,original.transform.position.z),
					Quaternion.identity
				);
				mobs [i].GetComponent<MobCharacter> ().rightSide = true;
			} 
			else
			{

				mobs [i] = Instantiate (
					original,
					new Vector3 (-10.0f,original.transform.position.y,original.transform.position.z),
					Quaternion.identity
				);
				mobs [i].GetComponent<MobCharacter> ().rightSide = false;
			}

			mobs[i].GetComponent<SpriteRenderer>().sprite = mobSprite [Random.Range (0, mobSprite.Length)];

			if (i < mobNum)
				mobs [i].GetComponent<MobCharacter> ().crowd = true;
			else
				mobs [i].GetComponent<MobCharacter> ().crowd = false;

			mobs [i].GetComponent<MobCharacter> ().pos = new Vector3 (Random.Range (-8.0f, 5.0f), original.transform.position.y, transform.position.z);

		}
	}

	void Update () 
	{
		for(int i = 0;i<mobNum;i++)
		{
			mobs [i].GetComponent<MobCharacter> ().crowd = true;
		}
		for(int i = mobNum;i<mobs.Length;i++)
		{
			mobs [i].GetComponent<MobCharacter> ().crowd = false;
		}
	}
}
