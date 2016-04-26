using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject pausedUI;
	public bool paused = false;
	private float someTime;

	void Start(){
		pausedUI.active = false;
	}

	void Update () {
		if (Input.GetKey (KeyCode.Escape))
		{
			paused = !paused;
		}

		if (paused)
		{
			pausedUI.active = true;
			Time.timeScale = 0f;
		}
		if (!paused)
		{
			pausedUI.active = false;
			//WaitForSeconds (0.5f);
			Time.timeScale = 1;
		}

	}
	public void Pause ()
	{
		paused = !paused;
	}
		
	public void Resume ()
	{
		paused = false;
	}
	public void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void MainMenu ()
	{
		Application.LoadLevel ("Title");
	}

}
