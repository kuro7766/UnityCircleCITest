using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpeedUp3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(OnDemandRendering.renderFrameInterval);
        OnDemandRendering.renderFrameInterval = 1;
    }
}
