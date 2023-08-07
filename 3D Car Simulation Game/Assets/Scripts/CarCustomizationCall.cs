using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCustomizationCall : MonoBehaviour
{

    public Renderer[] carMeshRenderer;
    public Material[] paintMaterialsCar1, paintMaterialsCar2, paintMaterialsCar3, paintMaterialsCar4, paintMaterialsCar5, paintMaterialsCar6, paintMaterialsCar7;

    public Material[] rimModelMaterialCar1, rimModelMaterialCar2, rimModelMaterialCar3, rimModelMaterialCar4, rimModelMaterialCar5, rimModelMaterialCar6, rimModelMaterialCar7;
    public Renderer[] carRimRendererCar1, carRimRendererCar2, carRimRendererCar3, carRimRendererCar4, carRimRendererCar5, carRimRendererCar6, carRimRendererCar7;

    public GameObject[] CarModels;

    [HideInInspector]
    public int carCounter, colorCounter;

    public static CarCustomizationCall instance;
    public void Awake()
    {
        instance = this;
        carCounter = PlayerPrefs.GetInt("ActiveCar") + 1;

        for (int i = 0; i < CarModels.Length; i++)
        {
            CarModels[i].SetActive(false);
        }
        CarModels[PlayerPrefs.GetInt("ActiveCar")].SetActive(true);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        CarCustomizationOnStart();
        
        
    }


    #region CarCustomizationWorking




    void CarPaintColor()
    {
        if (PlayerPrefs.GetInt("ActiveCar") == 0)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar1[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 1)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar2[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 2)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar3[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 3)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar4[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 4)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar5[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 5)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar6[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 6)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar7[colorCounter];
        }
    }

    void CarPaintColorOnStart()
    {
        if (PlayerPrefs.GetInt("ActiveCar") == 0)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar1[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 1)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar2[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 2)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar3[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 3)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar4[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 4)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar5[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 5)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar6[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 6)
        {
            carMeshRenderer[carCounter - 1].material = paintMaterialsCar7[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
    }

    void CarRimModel()
    {
        if (PlayerPrefs.GetInt("ActiveCar") == 0)
        {

            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar1[0].materials[0];
            mat[1] = rimModelMaterialCar1[colorCounter];
            carRimRendererCar1[0].materials = mat;
            carRimRendererCar1[1].materials = mat;
            carRimRendererCar1[2].materials = mat;
            carRimRendererCar1[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 1)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar2[0].materials[0];
            mat[1] = rimModelMaterialCar2[colorCounter];
            carRimRendererCar2[0].materials = mat;
            carRimRendererCar2[1].materials = mat;
            carRimRendererCar2[2].materials = mat;
            carRimRendererCar2[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 2)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar3[0].materials[0];
            mat[1] = rimModelMaterialCar3[colorCounter];
            carRimRendererCar3[0].materials = mat;
            carRimRendererCar3[1].materials = mat;
            carRimRendererCar3[2].materials = mat;
            carRimRendererCar3[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 3)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar4[0].materials[0];
            mat[1] = rimModelMaterialCar4[colorCounter];
            carRimRendererCar4[0].materials = mat;
            carRimRendererCar4[1].materials = mat;
            carRimRendererCar4[2].materials = mat;
            carRimRendererCar4[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 4)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar5[0].materials[0];
            mat[1] = rimModelMaterialCar5[colorCounter];
            carRimRendererCar5[0].materials = mat;
            carRimRendererCar5[1].materials = mat;
            carRimRendererCar5[2].materials = mat;
            carRimRendererCar5[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 5)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar6[0].materials[0];
            mat[1] = rimModelMaterialCar6[colorCounter];
            carRimRendererCar6[0].materials = mat;
            carRimRendererCar6[1].materials = mat;
            carRimRendererCar6[2].materials = mat;
            carRimRendererCar6[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 6)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar7[0].materials[0];
            mat[1] = rimModelMaterialCar7[colorCounter];
            carRimRendererCar7[0].materials = mat;
            carRimRendererCar7[1].materials = mat;
            carRimRendererCar7[2].materials = mat;
            carRimRendererCar7[3].materials = mat;
        }
       
    }

    void CarRimModelOnStart()
    {
        if (PlayerPrefs.GetInt("ActiveCar") == 0)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar1[0].materials[0];
            mat[1] = rimModelMaterialCar1[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar1[0].materials = mat;
            carRimRendererCar1[1].materials = mat;
            carRimRendererCar1[2].materials = mat;
            carRimRendererCar1[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 1)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar2[0].materials[0];
            mat[1] = rimModelMaterialCar2[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar2[0].materials = mat;
            carRimRendererCar2[1].materials = mat;
            carRimRendererCar2[2].materials = mat;
            carRimRendererCar2[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 2)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar3[0].materials[0];
            mat[1] = rimModelMaterialCar3[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar3[0].materials = mat;
            carRimRendererCar3[1].materials = mat;
            carRimRendererCar3[2].materials = mat;
            carRimRendererCar3[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 3)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar4[0].materials[0];
            mat[1] = rimModelMaterialCar4[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar4[0].materials = mat;
            carRimRendererCar4[1].materials = mat;
            carRimRendererCar4[2].materials = mat;
            carRimRendererCar4[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 4)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar5[0].materials[0];
            mat[1] = rimModelMaterialCar5[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar5[0].materials = mat;
            carRimRendererCar5[1].materials = mat;
            carRimRendererCar5[2].materials = mat;
            carRimRendererCar5[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 5)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar6[0].materials[0];
            mat[1] = rimModelMaterialCar6[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar6[0].materials = mat;
            carRimRendererCar6[1].materials = mat;
            carRimRendererCar6[2].materials = mat;
            carRimRendererCar6[3].materials = mat;
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 6)
        {
            Material[] mat = new Material[2];
            mat[0] = carRimRendererCar7[0].materials[0];
            mat[1] = rimModelMaterialCar7[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)];
            carRimRendererCar7[0].materials = mat;
            carRimRendererCar7[1].materials = mat;
            carRimRendererCar7[2].materials = mat;
            carRimRendererCar7[3].materials = mat;
        }
    }

  

 
    #endregion CarCustomizationWorking

    void CarCustomizationOnStart()
    {
        CarPaintColorOnStart();
        CarRimModelOnStart();
    }

}
