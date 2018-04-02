using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCheck : MonoBehaviour {

	public GameObject GarbageCan;
	public GameObject comboText;
	public GameObject FeverBackImage;
	public GameObject mob;
	public int comboCount;

	float feverTime;
	bool feverTrigger;
	public bool fever;


	void Start () {
		comboCount = 0;
		fever = false;
	}
	
	// Update is called once per frame
	void Update () {

		//feverCountを減らしていき、0になったらフィーバーが終わる
		if (feverTime > 0) {
			feverTime -= Time.deltaTime;
		} else {
            if (fever)
            {
                comboCount = 0;
            }
            fever = false;
			
		}

		GarbageCan.GetComponent<GarbageCan> ().fever = false;
		if (comboCount == 0) 
		{
			comboText.SetActive (false);

		}
		else if (comboCount < 3) 
		{
			comboText.SetActive (true);

			comboText.GetComponent<Text> ().text = comboCount + "Combo!";
		
		}

		if (fever) {
			comboText.GetComponent<Text> ().text = comboCount + "Combo!\nFEVER!!";
			FeverBackImage.SetActive (true);

		} else
			FeverBackImage.SetActive (false);


		if(comboCount >= 3)
		{
			if (!fever) {
				Fever ();
			}
		} 

	}

	void OnGUI()
	{
		if (fever)
		{
			GUIUtility.RotateAroundPivot (30.0f, FeverBackImage.GetComponent<RectTransform> ().rect.center);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Garbage") 
		{
			mob.GetComponent<Mob> ().mobNum--;
		}
	}

	void Fever()
	{
		feverTime = 10.0f;
		fever = true;
	}
}
