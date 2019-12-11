using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{

    public GameObject totem;
    public GameObject rotator;
    public Node button1;
    public Node button2;
    public GameObject platform;
    public GameObject realplat;
    public float targetY;
    public float targetY1;
    public GameObject block;
    bool risen;
    bool tower;
    GameObject player;
    Pathfinding p;
    // Start is called before the first frame update
    void Start()
    {
        risen = false;
        tower = false;
        player = GameObject.FindGameObjectWithTag("Player");
        p = player.GetComponent<Pathfinding>();
    }
    IEnumerator risePlat()
    {
        button1.gameObject.transform.GetChild(1).position -= Vector3.up;
        print("rising");
        risen = true;
        float dist = targetY - platform.transform.position.y;
        float dist1 = 0.49f - block.transform.position.y;

        for (int i=0; i<180;i++)
        {
            platform.transform.position += Vector3.up * (dist / 180);
            block.transform.position += Vector3.up * (dist1 / 180);
            yield return new WaitForEndOfFrame();
        }
        //realplat.SetActive(true);
       yield  return null;
    }
    // Update is called once per frame
    void Update()
    {
          if(p.GetCurrent().gameObject.CompareTag("locker") )Lock(true);
            else Lock(false);
        
        
        if (p.GetCurrent() == button1 && !risen) StartCoroutine( risePlat());
    }
    void Lock(bool locking)
    {
    
            rotator.GetComponent<BoxCollider>().enabled = !locking;
     
        print(locking); 
    }
}
