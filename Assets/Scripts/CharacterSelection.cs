using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
	public static int readyCount;
	public Racket player;
	public AI ai;
	public Image raptorSelected;
	public Image sonataSelected;
	public Image candymanSelected;
	
	void Start ()
	{
		Time.timeScale = 0;
		readyCount = 0;
		Raptor ();
		AiRaptor ();

	}

	void Update ()
	{
	 
	}

	public void Ready ()
	{
	    
		this.gameObject.SetActive (false);
		readyCount++;
		if (readyCount == 2) {
			Time.timeScale = 1;
		}


	}

	public void Raptor ()
	{
		
		player.character = "Raptor";
		raptorSelected.enabled = true;
		sonataSelected.enabled = false;
		candymanSelected.enabled = false;
	}

	public void Sonata ()
	{
		player.character = "Sonata";
		raptorSelected.enabled = false;
		sonataSelected.enabled = true;
		candymanSelected.enabled = false;
	}

	public void Candyman ()
	{
		player.character = "Candyman";
		raptorSelected.enabled = false;
		sonataSelected.enabled = false;
		candymanSelected.enabled = true;
	}

	//AI methods are here because of my bad design :(
	public void AiRaptor ()
	{
		
		ai.character = "Raptor";
		raptorSelected.enabled = true;
		sonataSelected.enabled = false;
		candymanSelected.enabled = false;
	}
	
	public void AiSonata ()
	{
		ai.character = "Sonata";
		raptorSelected.enabled = false;
		sonataSelected.enabled = true;
		candymanSelected.enabled = false;
	}
	
	public void AiCandyman ()
	{
		ai.character = "Candyman";
		raptorSelected.enabled = false;
		sonataSelected.enabled = false;
		candymanSelected.enabled = true;
	}


}
