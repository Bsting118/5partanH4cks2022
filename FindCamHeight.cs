using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FindCamHeight : MonoBehaviour {
    public GameObject ftDropdownLabel;
    public GameObject inchDropdownLabel;
    public GameObject tempCam;

    public int CalculateFtHeight(string ftStrVal)
    {
        int ftVal;

        try {
            ftVal = Convert.ToInt32(ftStrVal);
        }
        catch (OverflowException)
        {
            ftVal = 5;  //If overflow occurs, set feet value height to average rounded down of a human being
            //This should never happen, but better to be safe and sorry with having a backup substitute plan.
        }

        return ftVal;
    }

    public float CalculateInchHeight(string inchStrVal)
    {
        int inchVal;
        float inchesInFeet;
        try {
            inchVal = Convert.ToInt32(inchStrVal);
        }
        catch (OverflowException)
        {
            inchVal = 0;   //If overflow occurs, just round down to 0 to keep ft correct
            //This should never happen since it's only converting set valid drop down values, but better to be safe than sorry.
        }

        inchesInFeet = (inchVal / 12f);
        return inchesInFeet;
    }

    //To be used with setting Scene 2 camera rig height in Unity
    public float CalculateMeterCamHeight(string ftStr, string inchStr)
    {
        int ftVar = CalculateFtHeight(ftStr);
        float inchVar = CalculateInchHeight(inchStr);

        float totalFt = ftVar + inchVar;

        float meterHeightCalc = (totalFt / 3.2808f);  //Applying feet to meters conversion formula => [m = (ft / 3.2808)]

        return meterHeightCalc;

    }

    void Update()
    {
        Text ftDropdownText = ftDropdownLabel.GetComponent<Text>();
        Text inchDropdownText = inchDropdownLabel.GetComponent<Text>();

        string ftDropdownStrVal = ftDropdownText.text; //This will store the string num from the feet dropdown box
        string inchDropdownStrVal = inchDropdownText.text; //This will store the string num from the inch dropdown box

        tempCam.transform.position = new Vector3(0, CalculateMeterCamHeight(ftDropdownStrVal, inchDropdownStrVal), 0);

        Debug.Log(tempCam.transform.position);


    }
}
