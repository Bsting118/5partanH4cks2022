using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject ftDropdown;
    public GameObject inchDropdown;
    public GameObject tempCam;

    void Awake()
    {
        DontDestroyOnLoad(ftDropdown);
        DontDestroyOnLoad(inchDropdown);
        DontDestroyOnLoad(tempCam);
    }
}
