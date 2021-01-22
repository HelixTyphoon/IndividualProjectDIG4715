using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeTimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

 void FixedUpdate()
    {
         if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
