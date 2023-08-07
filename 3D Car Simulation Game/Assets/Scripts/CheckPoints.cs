using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    //FindObjectOfType<AudioManager>().playAudio("CheckPoint");
        //    Destroy(this.gameObject);
        //}
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            CheckPointManager.instance.CheckPointCrossed();
        }

    }
}