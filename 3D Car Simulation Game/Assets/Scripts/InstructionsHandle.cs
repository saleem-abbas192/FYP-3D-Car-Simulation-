using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsHandle : MonoBehaviour
{
    public GameObject InstructionBoxParent;

    public GameObject panel_OnRightIndicator, panel_OnLeftIndicator, panel_DriveSafe,
        panel_OneChanceLeft, parkingLane, steepAhead, steepBelow, slow, carWash, 
        noParking, busStop, atWork, parkingZone, dangerZone, noPhone, noSmoking, 
        speedLimit, trafficLight, hospital, uTurn, pedestrianWalk, laneDiscipline, 
        noHorn, noEntry, noOverTaking, noUturn, fourWayRoad, nocycle, petrolPump, rightLeftTurn, straightRightTurn, twoWayTraffic, stop;

    public GameObject instructionPanelParent;

    //public GameObject instructionPanel;
    //public GameObject drive, next;
    //int currentInst;

    public static InstructionsHandle instance;

    private void Awake()
    {
        //if (MenuManager.instance.levelNo == 1)
        //{
        //    instructionPanel.SetActive(true);
        //    instructionPanelParent.SetActive(true);
        //    next.SetActive(true);
        //    drive.SetActive(false);
        //    currentInst = 0;
        //    instructionPanel.transform.GetChild(currentInst).gameObject.SetActive(true);
        //    currentInst++;
        //}




        for (int i=0; i<instructionPanelParent.transform.childCount; i++)
        {
            if (i == MenuManager.instance.levelNo)
            {
                instructionPanelParent.transform.GetChild(i).gameObject.SetActive(true);
            }
            else 
                instructionPanelParent.transform.GetChild(i).gameObject.SetActive(false);
        }

        

    }

    void Start()
    {
        instance = this;
        DisableAllInstructionPanels();
    }

    public void DisableAllInstructionPanels()
    {
        for (int i = 0; i < InstructionBoxParent.transform.childCount; i++)
        {
            InstructionBoxParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void DisableStartInstructionPanel()
    {
        instructionPanelParent.SetActive(false);

        GameManager.instance.timeStartedInGamePlay = true;
        GameManager.instance.BeginTimer(0);
    }
    //public void SkipInstructions()
    //{
    //    instructionPanel.SetActive(false);
    //    instructionPanelParent.SetActive(false);
    //}

    //public void ReadInstructions()
    //{
        
    //    for (int i = 0; i < 6; i++)
    //    {
    //        instructionPanel.transform.GetChild(i).gameObject.SetActive(false);
    //    }

    //    if (currentInst == instructionPanel.transform.childCount)
    //    {
    //        next.SetActive(false);
    //        drive.SetActive(true);
    //        instructionPanelParent.SetActive(false);
    //    }
    //    else
    //    {
    //        instructionPanel.transform.GetChild(currentInst).gameObject.SetActive(true);
    //        currentInst++;
    //    }
        
    //}
}
