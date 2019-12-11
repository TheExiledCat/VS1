using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
    public Material wire;
    bool debug = false;
    Material[] mats;
    int[] indexes;
    GameObject player;
    Node prev;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        mats = new Material[ GameObject.FindObjectsOfType<Collider>().Length];
        indexes = new int[GameObject.FindObjectsOfType<Collider>().Length];
        for (int i = 0; i < GameObject.FindObjectsOfType<Node>().Length; i++)
        {
            GameObject.FindObjectsOfType<Node>()[i].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = debug;
        }
    }
    void Update()
    {
       
        prev = player.GetComponent<Pathfinding>().previous;
        if (prev)
            prev.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

        if (Input.GetKeyDown(KeyCode.F1))
        {
            debug = !debug;
            if (debug)
            {

                for (int i = 0; i < GameObject.FindObjectsOfType<MeshRenderer>().Length; i++)
                {

                    mats[i] = GameObject.FindObjectsOfType<MeshRenderer>()[i].GetComponent<MeshRenderer>().material;
                    indexes[i] = i;
                    GameObject.FindObjectsOfType<MeshRenderer>()[i].GetComponent<MeshRenderer>().material = wire;
                }
            }
            else
            {
                for (int i = 0; i < GameObject.FindObjectsOfType<MeshRenderer>().Length; i++)
                {
                    GameObject.FindObjectsOfType<MeshRenderer>()[i].GetComponent<MeshRenderer>().enabled = false;
                    GameObject.FindObjectsOfType<MeshRenderer>()[i].GetComponent<MeshRenderer>().material = mats[i];


                }
            }

            
            for (int i = 0; i < GameObject.FindObjectsOfType<Node>().Length; i++)
            {
                GameObject.FindObjectsOfType<Node>()[i].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = debug;
            }
        }

        player.GetComponent<Pathfinding>().GetCurrent().gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = !debug;
    }
}
