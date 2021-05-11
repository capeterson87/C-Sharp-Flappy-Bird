﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

	public float MaxTime = 1;
	private float CurrentTime = 0;
	public GameObject Obstacle;
	public float height;
	public float DeleteTime = 7;

    public bool isSpawning;
    // Start is called before the first frame update
    void Start()
    {
        isSpawning = true;
    }

    public void StopSpawning() {
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawning) {
        	if(CurrentTime > MaxTime) {
        		GameObject newObstacle = Instantiate(Obstacle);
        		newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        		Destroy(newObstacle, DeleteTime);
        		CurrentTime = 0;
        	}
        }
        
        CurrentTime += Time.deltaTime;
    }
}
