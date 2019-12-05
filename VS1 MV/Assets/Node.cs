using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    bool isEnd;
    public Collider[] closestNodes;
    public bool isClickable=true;
  public   Vector3 radius;
    public LayerMask nodes;
    public bool GetEnd()
    {
        return isEnd;
    }
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
        closestNodes = Physics.OverlapBox(transform.position,radius,Quaternion.identity,nodes);
     
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, radius);
    }
    public Collider[] GetNodes()
    {
        return closestNodes;
    }
}
