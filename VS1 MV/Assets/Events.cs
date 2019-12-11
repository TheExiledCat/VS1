using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
   public  Node teleportNode;
    public GameObject kopstuk;
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
    bool locking;
    GameObject player;
    public AudioClip buttonpress;
    public AudioClip groundrise;
    public AudioClip rotlock;
    public AudioClip pass;
    Pathfinding p;
    // Start is called before the first frame update
    void Start()
    {
        risen = false;
        tower = false;
        player = GameObject.FindGameObjectWithTag("Player");
        p = player.GetComponent<Pathfinding>();
    }
    IEnumerator liftTotem()
    {
        button2.transform.parent.gameObject.SetActive(false);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(buttonpress);
        tower = true;
        print("button2 pressed");
        float dist = 0.5f-totem.transform.position.y;

        for (int i = 0; i < 180; i++)
        {
            if (i == 20) Camera.main.GetComponent<AudioSource>().PlayOneShot(groundrise);
          
            totem.transform.position += Vector3.up * (dist / 180);
            yield return new WaitForEndOfFrame();
        }
        realplat.SetActive(true);
        yield return new WaitForEndOfFrame();
        p.SetCurrent(teleportNode);
        player.transform.position = teleportNode.Position;

        yield return null;
    }
    IEnumerator risePlat()
    {

        Camera.main.GetComponent<AudioSource>().PlayOneShot(buttonpress);
        button1.gameObject.transform.GetChild(1).position -= Vector3.up;
        print("rising");
        risen = true;
        float dist = targetY - platform.transform.position.y;
        float dist1 = 0.49f - block.transform.position.y;

        for (int i=0; i<180;i++)
        {
            if (i == 20) Camera.main.GetComponent<AudioSource>().PlayOneShot(groundrise);
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

          if (p.GetCurrent().gameObject.CompareTag("locker") )Lock(true);
            else Lock(false);

        if (p.GetCurrent() == button2 && !tower) StartCoroutine(liftTotem());
        if (p.GetCurrent() == button1 && !risen) StartCoroutine( risePlat());
    }
    void Lock(bool locking)
    {
       
        if (this.locking != locking)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(rotlock);

            
        }
        if (this.locking == true)
        {
            kopstuk.GetComponent<Animator>().SetTrigger("in");
        }
        else
        {
            kopstuk.GetComponent<Animator>().SetTrigger("out");
        }

        this.locking = locking;
        
        rotator.GetComponent<BoxCollider>().enabled = !locking;
        if (this.locking == false)
        {
            kopstuk.transform.localScale = new Vector3(1, 1, 1);
        }
        print(locking); 
    }
}
