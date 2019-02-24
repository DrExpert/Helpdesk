
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

	bool finished;

	public float timeToDo;

    Text text;

	GameController GC;
	ThingController TC;



	void Start()
	{
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
		}

	}

	void TriggerQuickTimeEvent ()
	{
		text.text = GoalMessage;
		started = true;
	}

	void SuccesQuickTimeEvent()
	{
		text.text = SuccesMessage;
		GC.addPoints (points);
	}
	void FailQuickTimeEvent()
	{
		text.text = FailMessage;
		GC.addPoints (-points);
		started = false;
		ring = false;
	}
}