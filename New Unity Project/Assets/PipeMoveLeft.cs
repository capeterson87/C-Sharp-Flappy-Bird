using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveLeft : MonoBehaviour
{

	public static float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * Vector3.left;
    }
}
