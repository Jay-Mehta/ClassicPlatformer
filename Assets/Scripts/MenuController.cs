using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public Text button;
	private string buttonText;
	public int firstTime = 1;

	// Use this for initialization
	void Start () {
		firstTime = PlayerPrefs.GetInt ("firstTimePref");
		if (firstTime == 0) {
			buttonText = "Start";
		} else {
			firstTime = 0;
			PlayerPrefs.SetInt ("firstTimePref", firstTime);
			buttonText = "Tutorial";
			Debug.Log ("buttonText");
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
		if (buttonText == "Start") {
			Application.LoadLevel ("Level01");
		} else {
			Application.LoadLevel ("Tutorial");
		}
	}
}
