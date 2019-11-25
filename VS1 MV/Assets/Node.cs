using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Collider[] closestNodes;
    [SerializeField]
    float radius =1;
    public LayerMask nodes;
   public  Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        closestNodes = Physics.OverlapSphere(transform.position, radius,nodes);
     
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public Collider[] GetNodes()
    {
        Collider[] arr = { closestNodes[1], closestNodes[2] };
        return arr;
    }
}
