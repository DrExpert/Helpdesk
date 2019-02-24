using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingController : MonoBehaviour
{
    private GameController GC;

    [SerializeField]
    private float mass;
    [SerializeField]
    public bool high;
    [SerializeField]
    public bool isTrash;
    [SerializeField]
    private int points = 10;
    public bool held;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("GameController");
        GC = obj.GetComponent<GameController>();
        if(high)transform.position = new Vector3(transform.position.x,  transform.position.y, -4);
        if(!high && transform.position.z >= 1){
            float pos = transform.position.z- Mathf.Floor(transform.position.z);
            transform.position = new Vector3(transform.position.x,  transform.position.y, pos);
        }
        points = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(GC==null){
            GameObject obj = GameObject.Find("GameController");
            GC = obj.GetComponent<GameController>();
        }
        Vector3 zeroHeight = new Vector3(transform.position.x, transform.position.y, 0);

        if(alive && !GC.getDeskBounds().Contains(zeroHeight) && !GC.getTrashBounds().Contains(zeroHeight) && !held){
            //spadanie przedmiotu
            Debug.LogWarning("SPADŁO!!!");
            // gameObject.SetActive(false);
            
            GC.resolveFloor(points);
            playDeathAnimation();
        }
        if(alive && !GC.getDeskBounds().Contains(zeroHeight) && GC.getTrashBounds().Contains(zeroHeight) && !held){
            //wyrzucanie przedmiotu
            Debug.LogWarning("w koszu!!!");
            // gameObject.SetActive(false);
            GC.resolveTrash(points,isTrash);
            playDeathAnimation();
        }
       
    }
    
    void playDeathAnimation(){
        
        alive = false;
        GetComponent<Collider2D>().enabled = false;
        //Dźwięk na spadanie (if trash etcetera)
        Animator anim = GetComponent<Animator>();
        GC.playClip();
        if(anim!=null)anim.SetTrigger("Dropit");
    }


    void OnMouseDown()
    {        
        if(!high)transform.position = new Vector3(transform.position.x,transform.position.y,-4);
        if(GC!=null){
            GC.getHand().setHolding(this.gameObject);
        }
        held = true;
    }
    void OnMouseUp()
    {
        GC.checkForTrashOnDesk();
        Debug.Log(GC.IshallGetHeight(GetComponent<Collider2D>()));
        held = false;
        // calculate newPosition
        // Debug.Log(0.15f*GC.IShallCountFlathThingsBeneath(GetComponent<Collider2D>()));
        if(!high)transform.position = new Vector3(transform.position.x,transform.position.y,GC.IshallGetHeight(GetComponent<Collider2D>()));
        if(GC!=null)GC.getHand().setLeave();
    }

    void OnMouseOver()
    {
        if(GC!=null && alive){
            Vector3 movement = GC.getHand().getMovement();
            transform.position += movement * (1/mass); 
        }
    }

}
