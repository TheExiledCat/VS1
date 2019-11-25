using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotat : MonoBehaviour
{
    public float rotSpeed = 20f;
    private float rotY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDrag()
    {
        rotY = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, rotY);
        print("cono");
    }

    // Update is called once per frame




}
