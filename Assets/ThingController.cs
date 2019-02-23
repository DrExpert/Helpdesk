using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingController : MonoBehaviour
{
    private GameController GC;
    [SerializeField]
    private float mass;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("GameController");
        GC = obj.GetComponent<GameController>();
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
        if(GC!=null)GC.getHand().setHolding(this.gameObject);
    }
    void OnMouseUp()
    {
        Debug.Log("left");
        if(GC!=null)GC.getHand().setLeave();
    }

    void OnMouseOver()
    {
        if(GC!=null){
            Vector3 movement = GC.getHand().getMovement();
            transform.position += movement * (1/mass); 
        }
    }
}
