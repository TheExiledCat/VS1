using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    GameObject black;
    GameObject ripple;
     Node current;
    bool searching = false;
    public Node target;
    Node closer;
    Node next;
    Node indexer;
    Node previous;
    Node previous1;
    public float speed;
    Ray ray;
    public bool moving=false;
    public Node GetCurrent()
    {
        return current;
    }
    // Start is called before the first frame update
    void Start()
    {
        black = (GameObject)Resources.Load("Particles/black"); 
        ripple = (GameObject)Resources.Load("Particles/singular ripple");
        indexer = GameObject.FindObjectsOfType<Node>()[0];
        for (int i = 0; i < GameObject.FindObjectsOfType<Node>().Length; i++)
        {
            if (Vector3.Distance(GameObject.FindObjectsOfType<Node>()[i].transform.position, transform.position) < Vector3.Distance(indexer.transform.position,transform.position)) indexer = GameObject.FindObjectsOfType<Node>()[i];
        }
        current = indexer;
        next = current;
    }
    void SetTarget()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit r;
        if(Physics.Raycast(ray,out r)){
           
            if (r.collider.gameObject.GetComponent<Node>()&& r.collider.gameObject.GetComponent<Node>().isClickable )
            {

                Destroy(Instantiate(ripple, r.transform.position, Quaternion.identity), 1);
                Destroy(Instantiate(black, r.transform.position+(Vector3.down*0.45f), Quaternion.identity), 1);
                target = r.collider.gameObject.GetComponent<Node>();
               
               
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        moving = false;
        if (Input.GetMouseButtonDown(0)) 
            SetTarget();

        if (Vector3.Distance(transform.position, current.transform.position) <= 0.0000000000000000000001f && target)
        {
            if (!searching && current != target)
                FindPath();
        }
           
        if(next&&current!=target)
        Follow(next);
        print(current);
        if(closer)
        print(closer);
    }
    void Follow(Node n)
    {
        Vector3 lTargetDir = n.Position- transform.position;
        lTargetDir.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 3);
        print("moving");
        moving = true;
        transform.position = Vector3.MoveTowards(transform.position,n.transform.position, speed/10);
    }
    void FindPath()
    {
        previous1 = previous;
        previous = current;
        closer = null;
        searching = true;
        if (target != null)
        {
           
         
            for (int i = 0; i < current.GetNodes().Length; i++)
            {
                if (previous1!= current.GetNodes()[i].GetComponent<Node>() && previous != current.GetNodes()[i].GetComponent<Node>() && current.GetNodes()[i].GetComponent<Node>().GetEnd())
                {
                    closer = current.GetNodes()[i].GetComponent<Node>();
                    break;
                }

                if (closer)
                {
                    print(Vector3.Distance(current.GetNodes()[i].transform.position, target.Position));
                    print(Vector3.Distance(closer.transform.position, target.Position));

                    if ((Vector3.Distance(current.GetNodes()[i].transform.position, target.Position) < Vector3.Distance(closer.transform.position, target.Position)) && current.GetNodes()[i].GetComponent<Node>() != current)
                    {
                        closer = current.GetNodes()[i].GetComponent<Node>();

                    }
                }
                else { 
                    closer = current.GetNodes()[i].GetComponent<Node>();

                }
            }
            

        }
        next = closer;
        searching = false;
        current = next;
    }
        
}
