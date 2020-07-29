using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float zAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
	}
}
