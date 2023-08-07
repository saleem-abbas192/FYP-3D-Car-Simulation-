using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdlesDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.collisionCount += 1;

            FindObjectOfType<AudioManager>().playAudio("Crash");
            if ((GameManager.instance.collisionCount >= 3 || GameManager.instance.timeRemaining <= 2f))
            {
                GameManager.instance.GameFailed();
            }
            if ((GameManager.instance.collisionCount == 1 || GameManager.instance.timeRemaining <= 2f))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.panel_DriveSafe.SetActive(true);
            }
            if ((GameManager.instance.collisionCount == 2 || GameManager.instance.timeRemaining <= 2f))
            {
                InstructionsHandle.instance.DisableAllInstructionPanels();
                InstructionsHandle.instance.panel_OneChanceLeft.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 20);
            }
        }
    }
}
