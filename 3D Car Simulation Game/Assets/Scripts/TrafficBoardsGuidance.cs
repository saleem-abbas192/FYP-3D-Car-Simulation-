using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficBoardsGuidance : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("parkinglane"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.parkingLane.SetActive(true);
            }
            if (this.gameObject.CompareTag("steepahead"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.steepAhead.SetActive(true);
            }
            if (this.gameObject.CompareTag("steepbelow"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.steepBelow.SetActive(true);
            }
            if (this.gameObject.CompareTag("slow"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.slow.SetActive(true);
            }
            if (this.gameObject.CompareTag("carwash"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.carWash.SetActive(true);
            }
            if (this.gameObject.CompareTag("noparking"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noParking.SetActive(true);
            }
            if (this.gameObject.CompareTag("busstop"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.busStop.SetActive(true);
            }
            if (this.gameObject.CompareTag("atwork"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.atWork.SetActive(true);
            }
            if (this.gameObject.CompareTag("parkingzone"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.parkingZone.SetActive(true);
            }
            if (this.gameObject.CompareTag("dangerzone"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.dangerZone.SetActive(true);
            }
            if (this.gameObject.CompareTag("nophone"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noPhone.SetActive(true);
            }
            if (this.gameObject.CompareTag("nosmoking"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noSmoking.SetActive(true);
            }
            if (this.gameObject.CompareTag("speedlimit"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.speedLimit.SetActive(true);
            }
            if (this.gameObject.CompareTag("trafficlight"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.trafficLight.SetActive(true);
            }
            if (this.gameObject.CompareTag("hospital"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.hospital.SetActive(true);
            }
            if (this.gameObject.CompareTag("uturn"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.uTurn.SetActive(true);
            }
            if (this.gameObject.CompareTag("pedestrianwalk"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.pedestrianWalk.SetActive(true);
            }
            if (this.gameObject.CompareTag("lanediscipline"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.laneDiscipline.SetActive(true);
            }
            if (this.gameObject.CompareTag("nohorn"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noHorn.SetActive(true);
            }
            if (this.gameObject.CompareTag("noentry"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noEntry.SetActive(true);
            }
            if (this.gameObject.CompareTag("noovertake"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noOverTaking.SetActive(true);
            }
            if (this.gameObject.CompareTag("nouturn"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.noUturn.SetActive(true);
            }
            if (this.gameObject.CompareTag("fourwayroad"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.fourWayRoad.SetActive(true);
            }
            if (this.gameObject.CompareTag("nocycle"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.nocycle.SetActive(true);
            }
            if (this.gameObject.CompareTag("petrolpump"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.petrolPump.SetActive(true);
            }
            if (this.gameObject.CompareTag("rightleftroad"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.rightLeftTurn.SetActive(true);
            }
            if (this.gameObject.CompareTag("straightrightroad"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.straightRightTurn.SetActive(true);
            }
            if (this.gameObject.CompareTag("twowayroad"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.twoWayTraffic.SetActive(true);
            }
            if (this.gameObject.CompareTag("stop"))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.stop.SetActive(true);
            }

        }


    }
}
