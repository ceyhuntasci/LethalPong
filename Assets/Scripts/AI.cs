using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{
	public GameMotor motor;
	public Ball ball;
	public string character = "";
	public int special = 0;
	public bool specialActivated = false;

	float reflexes;
	float sight;
	float speed;
	
	bool isThinking = false;
	bool isActing = false;
	float timer = 0f;


	void Start ()
	{
		reflexes = PlayerPrefs.GetFloat ("Reflexes");
		sight = PlayerPrefs.GetFloat ("Sight");
		speed = PlayerPrefs.GetFloat ("Speed");

		float padding;
		if (transform.position.x < 0) {
			padding = 10f;
		} else {
			padding = Screen.width - 10f;
		}
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (padding, Screen.height / 2, 10));	
	}
	

	void Update ()
	{
		if (special > 3) {
			ActivateSpecial ();
		}
		 
		if (!(transform.position.x - ball.transform.position.x > sight)) {

			isThinking = true;

		}
		if (isThinking && !isActing) {
			if (timer > 1f) {
				isThinking = false;
				isActing = true;
				timer = 0f;
			} else {
				timer += Time.deltaTime * reflexes;
			}	
		}
		if (isActing) {

			float y = ball.transform.position.y - transform.position.y;
			y = y * speed * Time.deltaTime;
			transform.Translate (0f, y, 0f);

			if (transform.position.x - ball.transform.position.x > sight) {
				isActing = false;
			}

		}

	}
	public void ActivateSpecial ()
	{
		if (special > 2) {
			special = -1;
			motor.ChangeImage (transform.position.x);
			specialActivated = true;
		} else {
		}
		
	}
	
}
