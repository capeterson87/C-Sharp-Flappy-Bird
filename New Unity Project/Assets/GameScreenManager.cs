using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenManager : MonoBehaviour
{

	public GameObject gameOverScreen;
	// public GameObject gameStartScreen;
	public GameObject score;
	bool atStartMenu;

    // Start is called before the first frame update
    void Start()
    {
    	atStartMenu = true;
    	gameOverScreen.SetActive(false);
    	// gameStartScreen.SetActive(true);
    	score.SetActive(true);
        Time.timeScale = 1;
    }

    public void Replay()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // void Update()
    // {
    // 	if(atStartMenu)
    // 	{	
    // 		gameStartScreen.SetActive(true);
    // 		Time.timeScale = 0;
    // 		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) 
    // 		{
    // 			atStartMenu = false;
    // 		} 
    // 	}
    // 	else 
    // 	{	
    // 			gameStartScreen.SetActive(false);
    // 	}
    // }

    public void GameOver() 
    {
        gameOverScreen.SetActive(true);
    }

    public bool AtStart()
    {
    	return atStartMenu;
    }
}
