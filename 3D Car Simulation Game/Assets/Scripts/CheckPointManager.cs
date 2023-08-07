using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public GameObject[] checkPoints;
    public int checkPointCrossedIndex;
    public static CheckPointManager instance;


    void Start()
    {
        instance = this;
        checkPointCrossedIndex = 0;

        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].SetActive(false);
        }
        checkPoints[checkPointCrossedIndex].SetActive(true);
        checkPointCrossedIndex += 1;
    }

    public void CheckPointCrossed()
    {
        //for (int i = 0; i < checkPoints.Length; i++)
        //{
        //    checkPoints[i].SetActive(false);
        //}

        if (checkPoints.Length != checkPointCrossedIndex)
        {
            checkPoints[checkPointCrossedIndex].SetActive(true);
            checkPointCrossedIndex += 1;
        }
    }
}
