using UnityEngine;
using System.Collections;

public class SwitchScenesV2Script : MonoBehaviour {
    
    public void SwitchScene (string destinationScene)
    {
        Application.LoadLevel(destinationScene);
    }

}