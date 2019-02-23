﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingController : MonoBehaviour
{
    [SerializeField]
    private GameController GC;
    [SerializeField]
    private float mass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        Debug.Log("catched");
        GC.getHand().setHolding(this.gameObject);
    }
    void OnMouseUp()
    {
        Debug.Log("left");
        GC.getHand().setLeave();
    }
    void OnMouseOver()
    {
    Vector3 movement = GC.getHand().getMovement();
    transform.position += movement * (1/mass);
    }
}
