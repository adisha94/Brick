using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * GM = Game manager script
 * Keeps track of basic mechanics of the game
 * */
public class GM : MonoBehaviour
{
	
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;
	private GameObject cloneBricks;
	
	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup();
		
	}

	/**
	 * Basic setup of the scene
	 * */
	public void Setup()
	{
		SetupPaddle ();
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
	}

	/**
	 * checks to see which end game text we are going to display
	 **/
	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		else if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}		
	}

	/**
	 * 
	 * Resets the game when method is called
	 **/
	void Reset()
	{
		Time.timeScale = 1f; // goes to normal time
		Application.LoadLevel(Application.loadedLevel);
	}

	/**
	 *
	 * Method executes when ball is missed
	 **/
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	/**
	 * 
	 * Initial setup of the paddle upon level loaduout
	 **/
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	/**
	 * 
	 * Initial setup of the Bricks upon level loaduout
	 **/
	void SetupBricks()
	{
		cloneBricks = Instantiate (bricksPrefab, transform.position, Quaternion.identity) as GameObject;
	}

	/**
	 * Executes upon impact of ball on brick
	 **/
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}