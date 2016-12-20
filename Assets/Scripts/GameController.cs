using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameController : MonoBehaviour {
	
	Canvas canvas;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
	}
	
	public void Pause()
	{
		canvas.enabled = !canvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void MainMenu()
	{
		Application.LoadLevel ("MainScene");
		Time.timeScale = 1;
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;
	}

	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}