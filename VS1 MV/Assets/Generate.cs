using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject nnode;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
         GameObject temp =Instantiate (nnode,  transform);
            temp.transform.localPosition = new Vector3(-4.5f+i, 1, 0);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
