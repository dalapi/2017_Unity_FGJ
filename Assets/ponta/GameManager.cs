using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private AudioSource sound01;

	// Use this for initialization
	void Start () {
        sound01 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

		//Spaceボタンを押した時
		if (Input.GetKeyUp(KeyCode.Space)) {

			//現在のシーン名を取得
			Scene scene = SceneManager.GetActiveScene();
            sound01.PlayOneShot(sound01.clip);

			//各シーンへ遷移
			switch ( scene.name ){

			case "Title":				//Titleの場合
				{
                    //Gameシーンに遷移する
                    Fade.Instance.LoadLevel("Tutorial", 0.5f);
					break;
				}

            case "Tutorial":				//Titleの場合
                {
                    //Gameシーンに遷移する
                    Fade.Instance.LoadLevel("Game", 0.5f);
                    break;
                }

			case "Game":				//Gameの場合
				{
                    //Resultシーンに遷移する
                    Fade.Instance.LoadLevel("Result", 0.1f);
                    break;
				}

			case "Result":				//Resultの場合
				{
                    //Titleシーンに遷移する
                    Fade.Instance.LoadLevel("Title", 0.5f);
                    break;
				}

			}

		}

	}
}
