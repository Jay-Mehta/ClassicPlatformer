﻿using UnityEngine;
using System.Collections;

public class Cycle : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < endPoint.position.x)
		{
			transform.position = new Vector3 (startPoint.position.x, transform.position.y, transform.position.z);
		}
	
	}
}
