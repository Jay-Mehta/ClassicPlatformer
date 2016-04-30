using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	private string startPlace;
	public int firstTime = 1;
	private int highScore ;

	// Use this for initialization
	void Start () {
		firstTime = PlayerPrefs.GetInt ("firstTimePref");
		if (firstTime == 0) {
			startPlace = "Start";
		} else {
			firstTime = 0;
			PlayerPrefs.SetInt ("firstTimePref", firstTime);
			startPlace = "Tutorial";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit ();
		}
	
	}

	public void StartGame()
	{
		if (startPlace == "Start") {
			Application.LoadLevel ("Level01");
		} else {
			Application.LoadLevel ("Tutorial");
		}
	}

	public void StartTutorial()
	{
		Application.LoadLevel ("Tutorial");
	}

	public void Reset()
	{
		PlayerPrefs.DeleteAll ();
		highScore = PlayerPrefs.GetInt ("scorePref");
		firstTime = 1;
		PlayerPrefs.SetInt ("firstTimePref", firstTime);
		Application.LoadLevel (Application.loadedLevel);

	}
}
