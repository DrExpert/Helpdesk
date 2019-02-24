using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private HandController hand;

    [SerializeField]
    private List<Collider2D> flatThings;
    [SerializeField]
    private List<ThingController> allThings;
    [SerializeField]
    private Transform thingsOnTableObject;
    [SerializeField]
    private Collider2D tableCollider, trashCollider;
    [SerializeField]
    public int Points;

    [SerializeField]
    private float timer;
    public HandController getHand(){
        return hand;
    }
    // Start is called before the first frame update
    void Start()
    {
        ThingController[] things = GetComponentsInChildren<ThingController>();
        foreach(ThingController thing in things){
            allThings.Add(thing);
            if(!thing.high)flatThings.Add(thing.gameObject.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = ""+Points;
        timer -= Time.deltaTime;
        int fixedTimer = (int)timer;
        timeText.text = fixedTimer.ToString();
    }
    public Bounds getDeskBounds(){
        Vector3 pos = tableCollider.bounds.center;
        Bounds deskBounds = new Bounds(new Vector3(pos.x,pos.y,0),tableCollider.bounds.size);
        return deskBounds;
    }
    public Bounds getTrashBounds(){
        Vector3 pos = trashCollider.bounds.center;
        Bounds trashBounds = new Bounds(new Vector3(pos.x,pos.y,0),tableCollider.bounds.size);
        return trashBounds;
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
    public void addPoints(int points){
        Points+=points;
    }
    public int checkForTrashOnDesk(){
        int ans=0;
        Debug.Log(allThings.Count);
        foreach(ThingController thing in allThings){
            if(thing.alive && thing.isTrash){
                ans++;
            }
        }
        Debug.Log(ans);
        return ans;
    }
    

    public float IshallGetHeight(Collider2D collider){
        int iter = 0;
        float pos = 0.1f;
        foreach(Collider2D coll in flatThings){
            // Vector3 zeroHeight = new Vector3(collider.gameObject.transform.position.x, collider.gameObject.transform.position.y, coll.gameObject.transform.position.z);
            Bounds bounds = new Bounds(new Vector3(collider.bounds.center.x,collider.bounds.center.y,coll.gameObject.transform.position.z),collider.bounds.size);
            if (coll != null && coll.bounds.Intersects(bounds) ){//&& coll.transform.position.z >= collider.transform.position.z ){
                iter++;
                if(coll.transform.position.z <= pos)pos  = coll.transform.position.z - 0.2f;
            } 
            //iter=collider.IsTouching(coll)?iter+1:iter;
        }
        Debug.Log(iter);
        return pos;
    } 
}
