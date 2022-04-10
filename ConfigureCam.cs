using System;
using UnityEngine;

public class ConfigureCam : MonoBehaviour {

    //public GameObject tempCam = GameObject.Find("TempCamera");
    public GameObject VRCam;
    void Start()
    {
        GameObject tempCam = GameObject.Find("TempCamera");

        //VECTOR! ...It's a mathematical term. A quantity represented by an arrow with both direction and magnitude! OH YAAA!
        float x = 0;
        float y = tempCam.transform.position.y;
        float z = 0;

        VRCam.transform.position = new Vector3(x, y, z);
    }
}