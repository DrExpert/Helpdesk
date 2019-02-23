using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingController : MonoBehaviour
{
    private GameController GC;
    [SerializeField]
    private float mass;
    [SerializeField]
    private bool high;
    [SerializeField]
    private bool isTrash;
    [SerializeField]
    private int points;
    public bool held;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("GameController");
        GC = obj.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GC==null){
            GameObject obj = GameObject.Find("GameController");
            GC = obj.GetComponent<GameController>();
        }
        Vector3 zeroHeight = new Vector3(transform.position.x, transform.position.y, 0);
        // Debug.Log(GC.getDeskBounds().Contains(zeroHeight));
        if(!GC.getDeskBounds().Contains(zeroHeight) && !GC.getTrashBounds().Contains(zeroHeight) && !held){
            //spadanie przedmiotu
            Debug.LogWarning("SPADŁO!!!");
            gameObject.SetActive(false);
            GC.resolveFloor(points);
        }
        if(!GC.getDeskBounds().Contains(zeroHeight) && GC.getTrashBounds().Contains(zeroHeight) && !held){
            //wyrzucanie przedmiotu
            
            gameObject.SetActive(false);
            GC.resolveTrash(points,isTrash);
        }
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
        Debug.Log(GC.IShallCountFlathThingsBeneath(GetComponent<Collider2D>()));
        held = false;
        // calculate newPosition
        if(!high)transform.position = new Vector3(transform.position.x,transform.position.y,(0.15f*GC.IShallCountFlathThingsBeneath(GetComponent<Collider2D>()))-0.1f);
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
