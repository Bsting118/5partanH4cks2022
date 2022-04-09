using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject ftDropdown;
    public GameObject inchDropdown;

    void Awake()
    {
        DontDestroyOnLoad(ftDropdown);
        DontDestroyOnLoad(inchDropdown);
    }
}