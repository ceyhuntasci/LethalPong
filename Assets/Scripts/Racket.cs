using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour
{
	float speed = 10f ;


	public string character = "";
	public int special = 0;
	public bool specialActivated = false;
	public GameMotor motor;
	
	void Start ()
	{	
		float padding;
		if (transform.position.x < 0) {
			padding = 10f;
		} else {
			padding = Screen.width - 10f;
		}
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (padding, Screen.height / 2, 10));		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		Touch touch = Input.GetTouch (0);
				
		float touchX = -9f + 18 * touch.position.x / Screen.width;
		float touchY = -5f + 10 * touch.position.y / Screen.height;


		if (Input.touchCount > 1) {
			Touch touch2 = Input.GetTouch (1);
			float touch2X = -9f + 18 * touch2.position.x / Screen.width;
			float touch2Y = -5f + 10 * touch2.position.y / Screen.height;

			if (touchX <= touch2X) {
				if (transform.position.x < 0) {
					MoveRacket (touchY);
				} else {
					MoveRacket (touch2Y);
					
				}
			} else {
				if (transform.position.x < 0) {
					MoveRacket (touch2Y);
				} else {
					MoveRacket (touchY);
					
				}
			}
		} else {
			if (touchX < 0 && transform.position.x < 0) {
				MoveRacket (touchY);
			} else if (touchX > 0 && transform.position.x > 0) {
				MoveRacket (touchY);
			}

		}	
	
	}

	void MoveRacket (float y)
	{
		if (Mathf.Abs (transform.position.y - y) > 0.2f) {
			if (Mathf.Abs (y) < 4.2f) {
				transform.Translate (0f, speed * Mathf.Sign (y - transform.position.y) * Time.deltaTime, 0f);
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
