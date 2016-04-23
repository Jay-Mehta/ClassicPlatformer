using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text highScoreText;
	[HideInInspector]public int highScore = 0;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("scorePref");
		highScoreText.text = highScore.ToString ("0");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
