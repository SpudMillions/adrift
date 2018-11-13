using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
	[SerializeField] private int playerLives = 3;
	[SerializeField] private int score = 0;
	[SerializeField] private Text livesText;
	[SerializeField] private Text scoreText;
	
	private void Awake()
	{
		var numGameSessions = FindObjectsOfType<GameSession>().Length;
		if (numGameSessions > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		livesText.text = "Lives: " + playerLives.ToString();
		scoreText.text = "Score: " + score.ToString();
	}

	public void AddToScore(int amountToAdd)
	{
		score += amountToAdd;
		scoreText.text = "Score: " + score.ToString();
	}

	public void ProcessPlayerDeath()
	{
		if (playerLives > 1)
		{
			TakeLife();
		}
		else
		{
			ResetGameSession();
		}
		
	}

	private void TakeLife()
	{
		playerLives--;
		livesText.text = "Lives: " + playerLives.ToString();
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}

	private void ResetGameSession()
	{
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}
}
