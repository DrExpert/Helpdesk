using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinnyThingController : MonoBehaviour
{
    private GameController GC;
    [SerializeField]
    private AudioClip drop;
    [SerializeField]
    private float mass;
    [SerializeField]
    public bool high;
    [SerializeField]
    private HandController hand;
    [SerializeField]
    public bool isTrash;
    [SerializeField]
    private int points;
    public bool held;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x,  transform.position.y, -4);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void playDeathAnimation(){
 
        GetComponent<Collider2D>().enabled = false;
        Animator anim = GetComponent<Animator>();
        if(anim!=null)anim.SetTrigger("Dropit");
    }


    void OnMouseDown()
    {        
        if(!high)transform.position = new Vector3(transform.position.x,transform.position.y,-4);
        if(hand!=null){
            hand.setHolding(this.gameObject);
        }
        held = true;
    }
    void OnMouseUp()
    {
        Debug.Log(GC.IshallGetHeight(GetComponent<Collider2D>()));
        held = false;
        if(hand!=null)hand.setLeave();
    }

    void OnMouseOver()
    {

    }

}
