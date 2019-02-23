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
        }
        if(!GC.getDeskBounds().Contains(zeroHeight) && GC.getTrashBounds().Contains(zeroHeight) && !held){
            //wyrzucanie przedmiotu
            Debug.LogWarning("W KOSZU!!!");
            gameObject.SetActive(false);
        }
    }


    void OnMouseDown()
    {
        Debug.Log("qweqweqweqwe");
        if(!high)transform.position = new Vector3(transform.position.x,transform.position.y,-4);
        if(GC!=null){
            Debug.Log("asdasdasd");
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
