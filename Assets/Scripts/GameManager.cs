﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	[SerializeField] Camera theCamera;

	private RaycastHit2D hit;

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		TouchRayCast ();
	}

	void TouchRayCast()
	{
		for (int i = 0; i < Input.touchCount; ++i) 
		{
			Vector2 test = theCamera.ScreenToWorldPoint (Input.GetTouch (i).position);

			if (Input.GetTouch (i).phase == TouchPhase.Began) 
			{
				test = theCamera.ScreenToWorldPoint (Input.GetTouch (i).position);

				RaycastHit2D hit = Physics2D.Raycast (test, (Input.GetTouch (i).position));
				if (hit.collider && hit.collider.tag == "Letter") 
				{

					AudioSource audioSource = hit.collider.GetComponent<AudioSource> ();
					audioSource.Play ();
				}
			}
		}
	}
}