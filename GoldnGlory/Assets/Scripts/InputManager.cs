using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	private Vector2 firstPosition;
	private Vector2 lastPosition;
	[SerializeField] private float dragDistance;
	
	// Use this for initialization
	void Start ()
	{
		dragDistance = Screen.width * 15 / 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				firstPosition = touch.position;
				lastPosition = touch.position;
			} else if (touch.phase == TouchPhase.Moved)
			{
				lastPosition = touch.position;
			} else if (touch.phase == TouchPhase.Ended)
			{
				lastPosition = touch.position;

				if (Math.Abs(lastPosition.x - firstPosition.x) > dragDistance)
				{
					if (lastPosition.x > firstPosition.x)
					{
						//Swipe Right
					} else if (lastPosition.x < firstPosition.x)
					{
						//Swipe Left
					}
					else
					{
						//Just tap
					}
				}
			}
		}
	}
	
}
