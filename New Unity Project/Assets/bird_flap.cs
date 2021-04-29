using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_flap : MonoBehaviour
{
	public float velocity = 1;
	private Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
        	RigidBody.velocity = Vector2.up * velocity;
        }
    }
}
