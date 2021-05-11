﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlap : MonoBehaviour
{

	public GameScreenManager sm;
	public ObstacleSpawner os;

	public float velocity = 1;
	public int score; //Keeps track of the user's code. (try to display this to screen???)
	public bool isLost = false;
	public bool disableControls = false;
	private Rigidbody2D RigidBody;
    Quaternion targetAngle_up = Quaternion.Euler (0,0,50);
    Quaternion targetAngle_down = Quaternion.Euler (0,0,-55);

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && !disableControls)
        {
        	RigidBody.velocity = Vector2.up * velocity; //Launches bird to represent flapping.
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle_up, 0.95f); //Rotates bird up when bird flaps.
        }
        if(isLost == false)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle_down, 0.0035f); //Constantly rotates bird down.
        }
        else
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler (0,0,-90), 0.01f); //When lost, the bird will rotate facing the ground.
        }
    }

    void BirdDies()
    {
        if (!isLost) //Ensures this code only runs once
        {
            RigidBody.velocity = Vector2.up * 3; //Simulates bird death
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle_up, 0.95f);
        }
        isLost = true;
        disableControls = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
            if (col.gameObject.name == "PipeGreenUp" || col.gameObject.name == "PipeGreenDown" || col.gameObject.name == "Ground")
            {
                BirdDies(); //Kills the bird if it hits the pipe or the ground.
                os.StopSpawning();
                sm.GameOver();
            }
            else if (col.gameObject.name == "Middle")
            {
                score = score + 1; //Updates the user's score when they pass between the pipes.
                Destroy(col.gameObject);
            }
    }

    public string GetScore()
    {
        return score.ToString();
    }
}