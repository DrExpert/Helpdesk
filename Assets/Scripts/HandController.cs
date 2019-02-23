using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private GameObject heldObject;

    [SerializeField]
    private Animator animator;

    private bool isHolding;
    // Start is called before the first frame update

    private Vector3 lastPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastPos = transform.position;
        //Movement
        Vector3 newPos = camera.ScreenToWorldPoint (Input.mousePosition);
        transform.position = new Vector3(newPos.x,newPos.y,-6);

        //Grabbing
        if (Input.GetMouseButtonDown(0)){
            // Debug.Log("grabbed");
            animator.SetBool("open",false);

        }
        if (Input.GetMouseButtonUp(0)){
            // Debug.Log("left it");
            animator.SetBool("open",true);
        }
        if(isHolding){
            heldObject.transform.position = new Vector3(newPos.x,newPos.y,heldObject.transform.position.z);
            //animacja od trzymania np. (powiększenie czy coś)
        }

    }
    public Vector3 getMovement(){
        return new Vector3(transform.position.x - lastPos.x, transform.position.y - lastPos.y, 0);
    }
    public void setHolding(GameObject obj){
        animator.SetBool("open",false);
        heldObject = obj;
        isHolding = true;
    }

    public void setLeave(){
        animator.SetBool("open",true);
        heldObject = null;
        isHolding = false;
    }
   
}
