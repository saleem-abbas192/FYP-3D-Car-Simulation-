using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    bool rightIndicatorOn;
    bool leftIndicatorOn;

    
    // Start is called before the first frame update
    void Start()
    {
        rightIndicatorOn = false;
        leftIndicatorOn = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.CompareTag("RightIndicator"))
        {
            //GameManager.instance.dentCharges.gameObject.SetActive(false);

            if (other.gameObject.CompareTag("Player"))
            {
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn == RCC_CarControllerV3.IndicatorsOn.Right)
                {
                    rightIndicatorOn = true;
                }
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right)
                {
                    InstructionsHandle.instance.panel_OnRightIndicator.SetActive(true);
                    rightIndicatorOn = false;
                }
            }
        }
        if (this.gameObject.CompareTag("LeftIndicator"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn == RCC_CarControllerV3.IndicatorsOn.Left)
                {
                    leftIndicatorOn = true;
                }
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left)
                {
                    InstructionsHandle.instance.panel_OnLeftIndicator.SetActive(true);
                    leftIndicatorOn = false;
                }
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (this.gameObject.CompareTag("RightIndicator"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn == RCC_CarControllerV3.IndicatorsOn.Right)
                {
                    rightIndicatorOn = true;
                    InstructionsHandle.instance.panel_OnRightIndicator.SetActive(false);
                }
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right && rightIndicatorOn == false)
                {
                    InstructionsHandle.instance.panel_OnRightIndicator.SetActive(true);
                    rightIndicatorOn = false;
                }
            }
        }
        if (this.gameObject.CompareTag("LeftIndicator"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn == RCC_CarControllerV3.IndicatorsOn.Left)
                {
                    leftIndicatorOn = true;
                    InstructionsHandle.instance.panel_OnLeftIndicator.SetActive(false);
                }
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left && leftIndicatorOn == false)
                {
                    InstructionsHandle.instance.panel_OnLeftIndicator.SetActive(true);
                    leftIndicatorOn = false;
                }
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (this.gameObject.CompareTag("RightIndicator"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Right && rightIndicatorOn == false)
                {
                    //GameManager.instance.totalScore -= 25;
                    //PlayerPrefs.SetInt("TotalScore", GameManager.instance.totalScore);
                    InstructionsHandle.instance.panel_OnRightIndicator.SetActive(false);

                    //GameManager.instance.dentCharges.gameObject.SetActive(true);
                }
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn == RCC_CarControllerV3.IndicatorsOn.Right || rightIndicatorOn == true)
                {
                    rightIndicatorOn = false;
                }

                this.gameObject.SetActive(false);
            }
        }

        if (this.gameObject.CompareTag("LeftIndicator"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn != RCC_CarControllerV3.IndicatorsOn.Left && leftIndicatorOn == false)
                {
                    //GameManager.instance.totalScore -= 25;
                    //PlayerPrefs.SetInt("TotalScore", GameManager.instance.totalScore);
                    InstructionsHandle.instance.panel_OnLeftIndicator.SetActive(false);

                    //GameManager.instance.dentCharges.gameObject.SetActive(true);
                }
                if (RCC_SceneManager.Instance.activePlayerVehicle.indicatorsOn == RCC_CarControllerV3.IndicatorsOn.Left || leftIndicatorOn == true)
                {
                    leftIndicatorOn = false;
                }

                this.gameObject.SetActive(false);
            }
        }
    }


}
