using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScreenController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("mouse 0"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
