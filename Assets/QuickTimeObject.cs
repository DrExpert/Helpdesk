using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


	GameController GC;
	ThingController TC;



	void Start()
	{
		TC = gameObject.GetComponent<ThingController> ();
		GameObject obj = GameObject.Find("GameController");
		GC = obj.GetComponent<GameController>();
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
		Debug.Log (GoalMessage);
		started = true;
	}

	void SuccesQuickTimeEvent()
	{
		Debug.Log (SuccesMessage);
		GC.addPoints (points);


	}
	void FailQuickTimeEvent()
	{
		Debug.Log (FailMessage);
		GC.addPoints (-points);
		started = false;
		ring = false;
	}
}