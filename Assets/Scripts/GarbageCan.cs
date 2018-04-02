using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCan : MonoBehaviour {

	public int score = 0;
	public GameObject inputParticle;
	public GameObject inputParticleFever;
	public GameObject score10Particle;
	public GameObject score20Particle;
	public GameObject comboCheck;
	public GameObject mob;

	AudioSource[] pointGets;

	public bool fever;

	void Start()
	{
		pointGets = GetComponents<AudioSource> ();
		fever = false;
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		//トリガーに入ったものにゴミタグがついていたら
		if (other.tag == "Garbage") 
		{
			other.tag = "Untagged";
			//ゴミ箱に入ったらパーティクルを放出する
			if (!comboCheck.GetComponent<ComboCheck> ().fever) 
			{
				Instantiate 
			(
					inputParticle,
					other.transform.position,
					inputParticle.transform.rotation
				);
				Instantiate 
				(
					score10Particle,
					other.transform.position,
					score10Particle.transform.rotation
				);

			}
			else 
			{
				Instantiate 
				(
					inputParticleFever,
					other.transform.position,
					inputParticleFever.transform.rotation
				);
				Instantiate 
				(
					score20Particle,
					other.transform.position,
					score20Particle.transform.rotation
				);

			}
				
			if (!comboCheck.GetComponent<ComboCheck>().fever) 
			{
				score += 10;	//加点する
			} 
			else 
			{
				score += 20;
			}

			if (comboCheck.GetComponent<ComboCheck>().fever)
			{
				pointGets [0].Play ();
			} 
			else
			{
				pointGets [1].Play ();
			}

			comboCheck.GetComponent<ComboCheck>().comboCount++;
			mob.GetComponent<Mob> ().mobNum++;

			other.GetComponent<SpriteRenderer> ().color = new Color (0.7f, 0.7f, 0.7f, 1.0f);	//入ったということがわかるように色を暗くする
			other.transform.parent = transform;		//タイムアップ時に
		}
	}


}
