using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    string morebs;
    // Start is called before the first frame update
    void Start()
    {
        morebs = Constants.bs;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //if(other.tag=="Player" Input.GetKey(KeyCode.w)){

       // }
    }
}
