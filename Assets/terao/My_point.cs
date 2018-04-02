using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
using System;

public class My_point : MonoBehaviour {

	int MyPint = 10;
	int[] test = new int[6];
	int point = -1;
	int My_Score;
	int Rank = 4,Xpos;

	Text MyPintText;
    Text dXpos;
	Text[] RankingPoint = new Text[5];
	Text[] Ranking = new Text[5];
	Image[] RankingBg = new Image[5];

	bool bRanking = true,First = true,Second = false;

	// Use this for initialization
	void Start () {
		MyPint = PlayerPrefs.GetInt ("PlayerScore");

		for(int i = 0; i < 5; i++){
			test[i] = PlayerPrefs.GetInt ("ranking(" + i + ")");
		}

        MyPintText = GameObject.Find("My_Point").GetComponent<Text>();

        dXpos = GameObject.Find("Ranking_Logo").GetComponent<Text>();

		RankingPoint[0] = GameObject.Find ("RANKING_1").GetComponent<Text> ();
		RankingPoint[1] = GameObject.Find ("RANKING_2").GetComponent<Text> ();
		RankingPoint[2] = GameObject.Find ("RANKING_3").GetComponent<Text> ();
		RankingPoint[3] = GameObject.Find ("RANKING_4").GetComponent<Text> ();
		RankingPoint[4] = GameObject.Find ("RANKING_5").GetComponent<Text> ();

		Ranking[0] = GameObject.Find ("RANKING_1_2").GetComponent<Text> ();
		Ranking[1] = GameObject.Find ("RANKING_2_2").GetComponent<Text> ();
		Ranking[2] = GameObject.Find ("RANKING_3_2").GetComponent<Text> ();
		Ranking[3] = GameObject.Find ("RANKING_4_2").GetComponent<Text> ();
		Ranking[4] = GameObject.Find ("RANKING_5_2").GetComponent<Text> ();

		RankingBg [0] = GameObject.Find ("RANKING_BG1").GetComponent<Image> ();
		RankingBg [1] = GameObject.Find ("RANKING_BG2").GetComponent<Image> ();
		RankingBg [2] = GameObject.Find ("RANKING_BG3").GetComponent<Image> ();
		RankingBg [3] = GameObject.Find ("RANKING_BG4").GetComponent<Image> ();
		RankingBg [4] = GameObject.Find ("RANKING_BG5").GetComponent<Image> ();

		//自分のScoreをランキングの6番目に入れる
		test [5] = MyPint;

		//ランキングの中を大きい順に入れ替える
		Array.Sort(test);
		Array.Reverse(test);

		int juni = 1;

		//表示
		for(int i = 0; i < 5; i++)
		{
			if ((test [i] == MyPint)&&(bRanking)) {
				Ranking [i].color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
				RankingPoint [i].color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
				bRanking = false;
			}
			Ranking [i].text = juni + "位" ;
			RankingPoint [i].text = test [i] + "点";
			juni++;
		}
		//保存
		for(int i = 0; i < 5; i++){
            PlayerPrefs.SetInt("ranking(" + i + ")", test[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (First) {			
			if (point < MyPint) {
				point++;
			} 
			else
			{
				First = false;
				Second = true;
			}

			MyPintText.text = point + " 点";
		}
			
		
		if(Second)
		{
			RankingBg [Rank].rectTransform.position += new Vector3(10, 0,0);

            if (RankingBg[Rank].rectTransform.position.x > dXpos.rectTransform.position.x)
			{
				Rank--;
			}
			if(Rank < 0)
			{
				Second = false;
			}

		}
	}
}
