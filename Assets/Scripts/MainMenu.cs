using UnityEngine;
using System.Collections;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour {

	public GameObject OptionsPanel;
	public GameObject MainPanel;
	public Slider sightSlider;
	public Slider reflexesSlider;
	public Slider speedSlider;

	void Start() {
		if (PlayerPrefs.HasKey ("Sight")) {
			sightSlider.value = PlayerPrefs.GetFloat ("Sight");
		} else {
			sightSlider.value = 10f;
		}
		if (PlayerPrefs.HasKey ("Reflexes")) {
			reflexesSlider.value = PlayerPrefs.GetFloat ("Reflexes");
		} else {
			reflexesSlider.value = 3f;
		}
		if (PlayerPrefs.HasKey ("Speed")) {
			speedSlider.value = PlayerPrefs.GetFloat ("Speed");
		} else {
			speedSlider.value = 3f;
		}

	}

	public void Play() {
		Application.LoadLevel("Level1");
	}
	public void TwoPlayer() {
		Application.LoadLevel("TwoPlayer");
	}

	public void Options(){


		MainPanel.SetActive (false);
		OptionsPanel.SetActive (true);
	}

	public void ReloadMenu(){
		OptionsPanel.SetActive (false);
		MainPanel.SetActive (true);

	}

	public void ChangeSight(){
		PlayerPrefs.SetFloat("Sight", sightSlider.value);
		
	}

	public void ChangeReflexes(){
		PlayerPrefs.SetFloat("Reflexes", reflexesSlider.value);
		
	}

	public void ChangeSpeed(){
		PlayerPrefs.SetFloat("Speed", speedSlider.value);
		
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
