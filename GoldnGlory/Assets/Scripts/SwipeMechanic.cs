using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using UnityEngine.UI;

public class SwipeMechanic : MonoBehaviour
{

	[SerializeField] private GameObject front;
	[SerializeField] private GameObject swipper;
	[SerializeField] private GameObject flipper;
	public Text teks;
	public Text storyTeks;

	public Sprite baseSprite;
	public Sprite nextSprite;

	//For define what is the next pointer
	private int stateChoice;
	
	// Use this for initialization
	void Start ()
	{
		storyTeks.text = Story.instance.dialogActive.dialog;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flipper.transform.rotation.eulerAngles.y == 90 && !GameVariables.swipe)
		{
			GameVariables.swipe = true;
			changeSprite();
		} else if (flipper.transform.rotation.eulerAngles.y == 0 && GameVariables.swipe)
		{
			front.GetComponent<Image>().sprite = flipper.GetComponent<Image>().sprite;
			front.GetComponent<Image>().enabled = true;
			flipper.GetComponent<Image>().sprite = baseSprite;

			GameVariables.inChanging = false;
			GameVariables.swipe = false;
		}
	}

	public GameObject Swipe(float lastPosition,float dragDirection)
	{
		front.transform.DORotate(new Vector3(0,0,10 * (lastPosition/dragDirection)), 0.5f,RotateMode.Fast);
		teks.text = lastPosition == -1 ? Story.instance.dialogActive.reject : Story.instance.dialogActive.accept;
		teks.alignment = lastPosition == -1 ? TextAnchor.UpperLeft : TextAnchor.UpperRight;
		return swipper;
	}

	public GameObject Normalize()
	{
		front.transform.DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast);
		return swipper;
	}

	public void Flipper(int direction)
	{
		stateChoice = direction == 1 ? 0 : 1;
		GameVariables.inChanging = true;
		front.transform.DORotate(new Vector3(0,0,180 * direction), 0.5f,RotateMode.Fast);
		flipper.transform.DORotate(new Vector3(0, 90, 0), 0.8f, RotateMode.Fast);
		swipper.SetActive(false);
	}

	private void changeSprite()
	{
		flipper.GetComponent<Image>().sprite = nextSprite;
		flipper.transform.DORotate(new Vector3(0, 0, 0), 0.8f, RotateMode.Fast);
		front.GetComponent<Image>().enabled = false;
		front.transform.DORotate(new Vector3(0, 0, 0), 0.8f, RotateMode.Fast);
		Story.instance.NextDialog(storyTeks,stateChoice);
	}
	
}
