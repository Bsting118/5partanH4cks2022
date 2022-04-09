using UnityEngine;
using System.Collections;

public class FindCamHeight : Monobehaviour {
    public GameObject ftDropdownLabel;
    public GameObject inchDropdownLabel;
    public GameObject tempCam;

    public double meterHeightCalc;

    public string ftDropdownStrVal; //This will store the string num from the feet dropdown box
    public string inchDropdownStrVal; //This will store the string num from the inch dropdown box

    public int CalculateFtHeight()
    {
        int ftVal;

        try {
            ftVal = Convert.ToInt32(ftDropdownStrVal);
        }
        catch (OverflowException)
        {
            ftVal = 5;  //If overflow occurs, set feet value height to average rounded down of a human being
            //This should never happen, but better to be safe and sorry with having a backup substitute plan.
        }

        return ftVal;
    }

    public double CalculateInchHeight()
    {
        int inchVal;
        double inchesInFeet;
        try {
            inchVal = Convert.ToInt32(inchDropdownStrVal);
        }
        catch (OverflowException)
        {
            inchVal = 0;   //If overflow occurs, just round down to 0 to keep ft correct
            //This should never happen since it's only converting set valid drop down values, but better to be safe than sorry.
        }

        inchesInFeet = (inchVal / 12);
        return inchesInFeet;
    }

    //To be used with setting Scene 2 camera rig height in Unity
    public void CalculateMeterCamHeight()
    {
        int ftVar = CalculateFtHeight();
        double inchVar = CalculateInchHeight();

        double totalFt = ftVar + inchVar;

        meterHeightCalc = (totalFt / 3.2808);  //Applying feet to meters conversion formula => [m = (ft / 3.2808)]

    }

    void Update()
    {
        Text ftDropdownText = ftDropdownLabel.GetComponent<Text>();
        Text inchDropdownText = inchDropdownLabel.GetComponent<Text>();

        ftDropdownStrVal = ftDropdownText.text; //This will store the string num from the feet dropdown box
        inchDropdownStrVal = inchDropdownText.text; //This will store the string num from the inch dropdown box

        //CalculateMeterCamHeight();

        tempCam.transform.position = new Vector3(0, CalculateMeterCamHeight(), 0);

        Debug.Log(tempCam.transform.position);


    }
}