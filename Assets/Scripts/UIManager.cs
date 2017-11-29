using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	private Text ScoreText { get; set; }
	private Text LifeText { get; set; }
	public int Score { get; set; }
	
	void Awake ()
	{
		this.ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		this.LifeText = GameObject.Find("LifeText").GetComponent<Text>();
	}

	public void UpdateScore(int score)
	{
		Score += score;
		ScoreText.text = $"Score:{Score}";
	}
	
	public void UpdateLife(int life)
	{
		LifeText.text = $"Life:{life}";
	}
}
