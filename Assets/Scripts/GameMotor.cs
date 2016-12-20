using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMotor : MonoBehaviour
{
	public Text player1ScoreText;
	public Text player2ScoreText;
	public Text winnerText;

	public Button HUDspecialLeft;
	public Button HUDspecialRight;
	public Sprite ballEmpty;
	public Sprite ballFull;


	public Ball ball;
	public AI ai;
	public Racket racket1;
	public Racket racket2;

	public float delay = 2f;

	float timer = 0f;
	bool delayed = false;
	bool isGameFinished = false;
	int throwDirection;
	int player1Score = 0;
	int player2Score = 0;

	void Start ()
	{
		winnerText.enabled = false;

	}
	

	void Update ()
	{

		if (delayed) {
			timer += Time.deltaTime;
			if (timer > delay) {
				delayed = false;
				NextRound (throwDirection);
			}
		}
		if (isGameFinished) {
			timer += Time.deltaTime;
			if (timer > 5f) {
				Application.LoadLevel ("MainScene");
			}
		}
	}
	void FixedUpdate ()
	{
		CheckStatus ();
	}
	void CheckStatus ()
	{
		if (ball.transform.position.x > 9) {
			PlayerScores (out player1Score, player1ScoreText, 1, player1Score);
		}
		if (ball.transform.position.x < -9) {
			PlayerScores (out player2Score, player2ScoreText, -1, player2Score);
		}
	}

	void PlayerScores (out int playerScore, Text playerText, int direction, int plus)
	{

		delayed = true;
		timer = 0f;
		ball.transform.position = new Vector3 (0f, 0f, 0f);
		ball.rb.velocity = new Vector3 (0f, 0f, 0f);
		ball.SendMessage ("ClearSpecials");
		playerScore = plus + 1;
		playerText.text = playerScore.ToString ();
		throwDirection = direction;
		
	}
	
	void NextRound (int i)
	{
		if (player1Score > 4) {
			MatchOver ("Player 1 Wins!");
			
		} else if (player2Score > 4) {
			MatchOver ("Player 2 Wins!");
			
		} else {

			ball.rb.AddForce (new Vector2 (5 * i, 0), ForceMode2D.Impulse);
		}
		
	}
	
	void MatchOver (string Message)
	{
		isGameFinished = true;
		winnerText.text = Message;
		winnerText.enabled = true;
		
	}

	public void ChangeImage (float i)
	{
		if (i < 0) {

			HUDspecialLeft.image.sprite = HUDspecialLeft.image.sprite == ballFull ? ballEmpty : ballFull;
		} else {
			HUDspecialRight.image.sprite = HUDspecialRight.image.sprite == ballFull ? ballEmpty : ballFull;
		}

	}
}
