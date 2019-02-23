using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;
    [SerializeField]
    private HandController hand;

    [SerializeField]
    private Collider2D[] flatThings;
    [SerializeField]
    private Collider2D tableCollider, trashCollider;
    [SerializeField]
    private int Points;

    public HandController getHand(){
        return hand;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = ""+Points;
    }
    public Bounds getDeskBounds(){
        return tableCollider.bounds;
    }
    public Bounds getTrashBounds(){
        return trashCollider.bounds;
    }

    public void resolveFloor(int points){
        Points = Points-Mathf.Abs(points);
    }
    public void resolveTrash(int points, bool isTrash){
        if(isTrash){
            Points = Points+Mathf.Abs(points);
            Debug.LogWarning("ŚMIEĆ W KOSZU :)))) !!!");
        }
        if(!isTrash){
            Points = Points-Mathf.Abs(points);
            Debug.LogWarning("POTRZEBNA RZECZ W KOSZU :(((( !!!");
        }
    }
    

    public int IShallCountFlathThingsBeneath(Collider2D collider){
        int iter = 0;
        // Vector3 zeroHeight = new Vector3(collider.gameObject.transform.position.x, collider.gameObject.transform.position.y, 0);
        // foreach(Collider2D coll in flatThings){
        //     if (coll != null && coll.bounds.Contains(zeroHeight)) iter++;
        //     //iter=collider.IsTouching(coll)?iter+1:iter;
        // }
        return iter;
    } 
}
