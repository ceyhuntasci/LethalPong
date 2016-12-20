using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{


	public float speed = 1f;
	public float speedGain = .5f;
	public Rigidbody2D rb ;
	public SpriteRenderer spr;
	public GameMotor motor;
	
	public bool goesThroughWalls = false;
	public bool wiggles = false;
	public bool movesSpecial = false;
	public bool transparent = false;

	bool alphaIncreasing = false; 
	float alphavalue = 1;

	void Start ()
	{
		spr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (-5, 0), ForceMode2D.Impulse);
	}

	void Update ()
	{

	}
	// We check for special movements in FixedUpdate and make the required changes on the ball
	void FixedUpdate ()
	{
		if (movesSpecial) {
			if (goesThroughWalls) {
				if (Mathf.Abs (transform.position.y) > 5) {
					transform.position = new Vector3 (transform.position.x, -transform.position.y, 0);
				}
			} else if (wiggles) {
				if (Mathf.Abs (transform.position.y) > 4f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - (0.2f * Mathf.Sign (transform.position.y)), 0f);
					rb.velocity = new Vector2 (rb.velocity.x, 0.5f * -Mathf.Sign (rb.velocity.y));
				} else {
					rb.AddForce (new Vector2 (0, 0.3f * Mathf.Sign (rb.velocity.y)), ForceMode2D.Impulse);
				}
			} else if (transparent) {
				if (alphaIncreasing) {
					alphavalue += 0.015f;
					if (alphavalue >= 1f)
						alphaIncreasing = false;
				} else {
					alphavalue -= 0.015f;
					if (alphavalue <= 0f)
						alphaIncreasing = true;
				}
				spr.color = new Color (1f, 1f, 1f, alphavalue);
				if (Mathf.Abs (transform.position.y) > 4.8f) {
					rb.velocity = new Vector2 (rb.velocity.x, -rb.velocity.y);
				}
			}
		} else {
			if (Mathf.Abs (transform.position.y) > 4.8f) {
				rb.velocity = new Vector2 (rb.velocity.x, -rb.velocity.y);
			}

		}


	}
	//Checks collision, adds velocity according to hit point
	//Then checks the special cases for activating them
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Racket") {

			if (movesSpecial) {
				ClearSpecials ();
			}

			float velocityX = rb.velocity.x + (speedGain * Mathf.Sign (rb.velocity.x));
			velocityX = -velocityX;

			float velocityY = (transform.position.y - col.transform.position.y) * 3f;
			
			Vector2 dir = new Vector2 (velocityX, velocityY);
			
			rb.velocity = dir;

			if (col.transform.position.x < 0) {
			
				motor.racket1.special += 1;
				if (motor.racket1.special == 3) {
					motor.ChangeImage (motor.racket1.transform.position.x);
				}
				if (motor.racket1.specialActivated) {
					if (motor.racket1.character == "Raptor") {
						movesSpecial = true;
						transparent = true;
						motor.racket1.specialActivated = false;
					} else if (motor.racket1.character == "Sonata") {
						movesSpecial = true;
						wiggles = true;
						motor.racket1.specialActivated = false;
					} else if (motor.racket1.character == "Candyman") {
						movesSpecial = true;
						goesThroughWalls = true;
						motor.racket1.specialActivated = false;
					}

				}
			} else if (col.transform.position.x > 0) {
			
				if (Application.loadedLevel == 1) {
					motor.ai.special += 1;
					if (motor.ai.special == 3) {
						motor.ChangeImage (motor.ai.transform.position.x);
					}
					if (motor.ai.specialActivated) {
						if (motor.ai.character == "Raptor") {
							movesSpecial = true;
							transparent = true;
							motor.ai.specialActivated = false;
						} else if (motor.ai.character == "Sonata") {
							movesSpecial = true;
							wiggles = true;
							motor.ai.specialActivated = false;
						} else if (motor.ai.character == "Candyman") {
							movesSpecial = true;
							goesThroughWalls = true;
							motor.ai.specialActivated = false;
						}						
					}
				} else {
					motor.racket2.special += 1;
					if (motor.racket2.special == 3) {
						motor.ChangeImage (motor.racket2.transform.position.x);
					}
					if (motor.racket2.specialActivated) {
						if (motor.racket2.character == "Raptor") {
							movesSpecial = true;
							transparent = true;
							motor.racket2.specialActivated = false;
						} else if (motor.racket2.character == "Sonata") {
							movesSpecial = true;
							wiggles = true;
							motor.racket2.specialActivated = false;
						} else if (motor.racket2.character == "Candyman") {
							movesSpecial = true;
							goesThroughWalls = true;
							motor.racket2.specialActivated = false;
						}						
					}


				}
			}
		}

	}
	//Make the ball normal again
	public void ClearSpecials ()
	{
		spr.color = new Color (1f, 1f, 1f, 1f);
		alphavalue = 1;
		alphaIncreasing = false;
		movesSpecial = false;
		transparent = false;
		goesThroughWalls = false;
		wiggles = false;
	}



}
