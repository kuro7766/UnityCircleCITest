using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    private GameObject r;
    // Start is called before the first frame update
    void Start()
    {
        r = GameObject.Find("abc");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(r.transform.position,Vector3.back,Time.deltaTime*500);
        // transform.Rotate(Vector3.forward,Space.Self);
    }

}
