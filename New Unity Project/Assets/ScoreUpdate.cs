using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
	Text txt;
    public BirdFlap bf;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = bf.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = bf.GetScore();
    }
}
