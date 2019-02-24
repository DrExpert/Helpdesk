
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuickTimeObject : MonoBehaviour {

	//type
	private bool ring;

	private bool started;

	public AudioClip clip;

	//Message
	[SerializeField]
	private string GoalMessage;
	[SerializeField]
	private string SuccesMessage;
	[SerializeField]
	private string FailMessage;
	[SerializeField]
	private int requiredPoints;
	[SerializeField]
	private int points;

	[SerializeField]
	private Image img;
	[SerializeField]
	private Text textTimer;
	Color _color;

	public GameObject obrazek;
	public Sprite ringon;
	public Sprite ringoff;
	bool finished;

	public float timeToDo;

    Text text;

	GameController GC;
	ThingController TC;



	void Start()
	{
		_color.a = 1;
		_color.r = 1;
		_color.g = 1;
		_color.b = 1;
		TC = gameObject.GetComponent<ThingController> ();
		GameObject obj = GameObject.Find("GameController");
		GC = obj.GetComponent<GameController>();
        text = GameObject.Find("QuickTimeEventsText").GetComponent<Text>();
	}

	void Update()
	{
		if (GC.Points >= requiredPoints && !finished)
		{
			ring = true;
		}
		//set ring from elsewhere to trigger the event
		if (ring==true && !started)
		{
			TriggerQuickTimeEvent ();
		} 

		if (ring == true && TC.held == true && started == true && !finished) 
		{
			started = false;
			ring = false;
			finished = true;
			SuccesQuickTimeEvent ();
		}

		if (ring == true && timeToDo <= 0) 
		{
			FailQuickTimeEvent ();
		}
		if (started == true)
		{
			timeToDo -= Time.deltaTime;
			int timeToDoInt = (int)timeToDo; 
			textTimer.text = timeToDoInt.ToString();
		}
		
	}

	void TriggerQuickTimeEvent ()
	{
		SwapImage();
		text.text = GoalMessage;
		textTimer.color = _color;
		img.color = _color;
		started = true;
	}
	void SwapImage()
	{	
		if(ring)
		{
		obrazek.GetComponent<SpriteRenderer>().sprite = ringon ;
		}else
		{
		obrazek.GetComponent<SpriteRenderer>().sprite = ringoff;
		}
	}
	void SuccesQuickTimeEvent()
	{
		
		HideImage();
		text.text = SuccesMessage;
		GC.addPoints (points);
		ring= false;
		SwapImage();
	}
	void FailQuickTimeEvent()
	{
		
		HideImage();
		text.text = FailMessage;
		GC.addPoints (-points);
		started = false;
		ring = false;
		SwapImage();
	}
	void HideImage()
	{
		_color.a = 0;
		textTimer.color = _color;
		img.color = _color;
	}
}