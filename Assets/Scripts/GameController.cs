using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public const float startCountDown = 5.0f;
	public Text ScoreText;
	public Text TimerText;
	public GameObject GarbageCan;

	public GameObject Shooter;
	public GameObject StartPanel;
	public GameObject FinishPanel;

	[SerializeField]
	public float countDown = 60.0f;
	float oneTwoThree = startCountDown + 1.0f;
	AudioSource[] soundEffects;

	bool timeUp = false;
	bool started = false;

	void Start () 
	{
		soundEffects = GetComponents<AudioSource> ();
		Time.timeScale = 0.0f;
		oneTwoThree = startCountDown + 1.0f;
	}

	void Update () 
	{

		if (!timeUp) 
		{
			if (!started) 
			{
				//ゲーム開始前の演出
				oneTwoThree = Time.realtimeSinceStartup;
				Debug.Log (oneTwoThree);
				if (oneTwoThree < startCountDown)
				{
					StartPanel.transform.Find ("OpeningText").GetComponent<Text> ().text = (startCountDown + 1 - oneTwoThree).ToString ("f0");
				} 
				else 
				{
					soundEffects [1].Play ();
					StartPanel.transform.Find ("OpeningText").GetComponent<Text> ().fontSize = 70;
					StartPanel.transform.Find ("OpeningText").GetComponent<Text> ().text = "START !!";
				}

				if (oneTwoThree > startCountDown + 1.0f)
				{
					started = true;
					StartPanel.SetActive (false);
					Time.timeScale = 1.0f;
				}

			}
			else
			{
				
				//タイムアップ前の処理
				countDown -= Time.deltaTime;

				if (countDown <= 0) {
					Debug.Log ("TIME UP!");
					timeUp = true;
				}
			}
		} 
		else 
		{
			//タイムアップ後の処理
			Destroy(Shooter);
			soundEffects [2].Play ();
			FinishPanel.SetActive (true);
			PlayerPrefs.SetInt ("PlayerScore", GarbageCan.GetComponent<GarbageCan> ().score);
            if (Input.GetKey("space"))
            {
				soundEffects[0].Play ();
                Fade.Instance.LoadLevel("Result", 0.1f);
            }
		}
	}

	void OnGUI()
	{
		ScoreText.text = "Score:" + GarbageCan.GetComponent<GarbageCan> ().score;
		TimerText.text = "TIME:" + countDown.ToString("f1");
	}


	public void PushResultButton()
	{
		//リザルト画面へ遷移する
		//SceneManager.LoadScene ("Result");
		Debug.Log("Push Result Button");
	}
}
