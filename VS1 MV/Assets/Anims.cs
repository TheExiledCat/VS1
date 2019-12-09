using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour
{

    Animator anim;
    Pathfinding p;
    [SerializeField]
    bool climbing;
    public GameObject lookpoint;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        p = transform.parent.gameObject.GetComponent<Pathfinding>();
       
    }

    // Update is called once per frame
    void Update()
    {
        climbing = p.climbing;
     
        
        
        if(climbing&&lookpoint)
            transform.LookAt(new Vector3(lookpoint.transform.position.x, transform.position.y, lookpoint.transform.position.z));





        anim.SetBool("idle", !p.moving);
        anim.SetBool("climbing", climbing);
    }
}
