using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
	private Vector2 firstPosition;
	private Vector2 lastPosition;
	private float dragDistance;
	[SerializeField] private SwipeMechanic swipe;

	// Use this for initialization
	void Start ()
	{
		dragDistance = Screen.width * 20 / 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameVariables.inChanging || GameVariables.comingSoon) return;
		if (Story.instance.dialogActive.doubleChoice) DoubleLink();
		else SingleLink();
	}

	void SingleLink()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
			
			} else if (touch.phase == TouchPhase.Ended)
			{
				Ray raycast = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit2D hit = Physics2D.Raycast(raycast.origin, raycast.direction);
				if (hit.collider != null && hit.collider.CompareTag("Card"))
				{
					swipe.Flipper(1);
				}

			}
		}
	}

	void DoubleLink()
	{
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
				if (lastPosition.x > firstPosition.x)
				{
					//Swipe Right
					swipe.Swipe(-1,1).SetActive(true);
				} else if (lastPosition.x < firstPosition.x)
				{
					//Swipe Left
					swipe.Swipe(1,1).SetActive(true);
				}
			} else if (touch.phase == TouchPhase.Ended)
			{
				lastPosition = touch.position;
				float temp = lastPosition.x - firstPosition.x;

				if (Math.Abs(temp) > dragDistance)
				{
					if (lastPosition.x > firstPosition.x)
					{
						//Swipe Right
						swipe.Flipper(-1);

					} else if (lastPosition.x < firstPosition.x)
					{
						//Swipe Left
						swipe.Flipper(1);
					}
					else
					{
						//Just tap
						
					}
				}
				else
				{
					swipe.Normalize().SetActive(false);
					
				}
			}
		}
	}

}
