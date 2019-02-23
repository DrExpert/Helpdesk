using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("asdasdasd");
        if(other.tag == "Thing" && !other.gameObject.GetComponent<ThingController>().held){
            //animacja wyrzucania
            other.gameObject.SetActive(false);
        }
    }
}
