using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Node current;
    Node target;
    Node closer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        closer = null;
    }
    void FindPath()
    {
        if (target != null)
        {
            Node next;
         
            for (int i = 0; i < current.GetNodes().Length; i++)
            {
                if(Vector3.Distance(current.GetNodes()[i].transform.position, target.Position) < Vector3.Distance(closer.transform.position, target.Position){

                }
            }
            




        }
     
    }
}
