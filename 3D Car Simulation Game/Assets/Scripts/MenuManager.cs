using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject garagePanel;
    public GameObject mainLevelPanel;
    public GameObject exitPanel;
    public GameObject settingPanel;
    public GameObject loadingPanel;
    public GameObject DailyRewardPanel;
    public GameObject colorCustomizationPanel;
    public GameObject rimCustomizationPanel;

    public GameObject[] carModels;
    public GameObject[] carButtons;
    public Text carPriceText;
    public int[] carModelPrices;
    public GameObject[] carSpecs;

    public GameObject buyButton;
    public GameObject selectButton;
    public GameObject colorButton;
    public GameObject rimButton;

    public Button[] ChapOneLevelButton;

    public Slider musicSlider;
    public Slider soundSlider;

    [Header("Setting Controlls")]
    public Image[] buttonControllers;
    public Sprite[] UnSelectedControllers;
    public Sprite[] SelectedControllers;

    public Text dailyRewardTimer;
    public Text coins;
    int carCounter;
    public int levelNo;


    /// <summary>
    /// Customization Part
    /// </summary>
    public GameObject[] paintColorButtons;
    public Renderer[] carMeshRenderer;
    public Material[] paintMaterialsCar1, paintMaterialsCar2, paintMaterialsCar3, paintMaterialsCar4, paintMaterialsCar5, paintMaterialsCar6, paintMaterialsCar7;

    public GameObject[] rimModelBtns;
    public Material[] rimModelMaterialCar1, rimModelMaterialCar2, rimModelMaterialCar3, rimModelMaterialCar4, rimModelMaterialCar5, rimModelMaterialCar6, rimModelMaterialCar7;
    public Renderer[] carRimRendererCar1, carRimRendererCar2, carRimRendererCar3, carRimRendererCar4, carRimRendererCar5, carRimRendererCar6, carRimRendererCar7;

    public GameObject equip, equipped, buy;

    int colorCounter;


    public static MenuManager instance;
    public void Start()
    {
        instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        equip.SetActive(false);
        equipped.SetActive(false);
        buy.SetActive(false);

        HideAllMainPanel();
        CarModelsSetting();
        PlayerPrefInitialization();
        LevelButtonsOnStart();
        ControlsOnStart();
        soundSlider.value = PlayerPrefs.GetFloat("SoundSliderValue");
        musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue");
        menuPanel.SetActive(true);

        carCounter = PlayerPrefs.GetInt("ActiveCar") + 1;
        CarCustomizationOnStart();
    }


    public void Update()
    {
        carPriceText.text = carModelPrices[carCounter-1].ToString();
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
        PlayerPrefs.SetFloat("SoundSliderValue", soundSlider.value);
        PlayerPrefs.SetFloat("MusicSliderValue", musicSlider.value);
    }

    void LevelButtonsOnStart()
    {
        
        for (int i = 0; i < ChapOneLevelButton.Length; i++)
        {
            ChapOneLevelButton[i].interactable = false;
            ChapOneLevelButton[i].transform.localScale = new Vector3(1f, 1f, 1f);
            ChapOneLevelButton[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("ChapterOneLevelUnlock") + 1; i++)
        {
            Debug.Log(PlayerPrefs.GetInt("ChapterOneLevelUnlock"));
            ChapOneLevelButton[i].interactable = true;
            ChapOneLevelButton[i].transform.localScale = new Vector3(1.05f, 1.15f, 1f);
            ChapOneLevelButton[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        
        
    }


    public void LoadHome()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        HideAllMainPanel();
        menuPanel.SetActive(true);

        for (int i = 0; i < carModels.Length; i++)
        {
            carModels[i].SetActive(false);
        }
        carModels[PlayerPrefs.GetInt("Player")].SetActive(true);

    }

    public void LoadGaragePanel()
    {
        FindObjectOfType<AudioManager>().playAudio("PlayButtonClick");
        Debug.Log(PlayerPrefs.GetInt("ActiveCar"));

        equip.SetActive(false);
        equipped.SetActive(false);
        buy.SetActive(false);

        CarPaintColorOnStart();
        CarRimModelOnStart();


        HideAllMainPanel();
        garagePanel.SetActive(true);
    }

   

    public void ChooseLevel(int level)
    {
        if((level >= 0 && level <= 8) || (level >= 10 && level <= 18) || (level >= 20 && level <= 28) || (level >= 30 && level <= 38))
        {
            levelNo = level;
            Invoke("LoadNextScene", 8f);
        }
        else
        {
            levelNo = level;
            Invoke("LoadQuizScene", 8f);
        }

        FindObjectOfType<AudioManager>().playAudio("click");
        HideAllMainPanel();
        loadingPanel.SetActive(true);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }

    void LoadQuizScene()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().playAudio("click");
        Application.Quit();
    }

    public void LoadExit()
    {
        FindObjectOfType<AudioManager>().playAudio("click");
        HideAllMainPanel();
        loadingPanel.SetActive(true);
        Invoke("LoadExitHandle", 2f);

    }


    public void DailyReward()
    {
        HideAllMainPanel();
        DailyRewardPanel.SetActive(true);
    }


    void LoadExitHandle()
    {
        HideAllMainPanel();
        exitPanel.SetActive(true);

    }

    public void LoadSetting()
    {
        FindObjectOfType<AudioManager>().playAudio("click");
        HideAllMainPanel();
        loadingPanel.SetActive(true);
        Invoke("SettingHandle", 2f);

    }

    void SettingHandle()
    {
        HideAllMainPanel();
        settingPanel.SetActive(true);
    }

    public void LoadColorCustomization()
    {
        HideAllMainPanel();
        PaintColorOnStart();
        SetCustomizationPlayerPref();
        colorCustomizationPanel.SetActive(true);
    }

    public void LoadRimCustomization()
    {
        HideAllMainPanel();
        RimModelOnStart();
        SetCustomizationPlayerPref();
        rimCustomizationPanel.SetActive(true);
    }

    void HideAllMainPanel()
    {
        menuPanel.SetActive(false);
        garagePanel.SetActive(false);
        mainLevelPanel.SetActive(false);
        exitPanel.SetActive(false);
        settingPanel.SetActive(false);
        loadingPanel.SetActive(false);
        colorCustomizationPanel.SetActive(false);
        rimCustomizationPanel.SetActive(false);
        DailyRewardPanel.SetActive(false);
    }

    
    
    public void ShowLevelPanel()
    {
        HideAllMainPanel();
        mainLevelPanel.SetActive(true);
    }





    void CarModelsSetting()
    {
        for (int i = 0; i < carModels.Length; i++)
        {
            carModels[i].SetActive(false);
            carSpecs[i].SetActive(false);

            carButtons[i].transform.GetChild(0).transform.gameObject.SetActive(false);
            carButtons[i].transform.GetChild(1).transform.gameObject.SetActive(false);
        }
        carModels[PlayerPrefs.GetInt("ActiveCar")].SetActive(true);
        carSpecs[PlayerPrefs.GetInt("ActiveCar")].SetActive(true);

        carButtons[PlayerPrefs.GetInt("ActiveCar")].transform.GetChild(0).transform.gameObject.SetActive(true);
        carButtons[PlayerPrefs.GetInt("ActiveCar")].transform.GetChild(1).transform.gameObject.SetActive(false);
        carButtons[PlayerPrefs.GetInt("ActiveCar")].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        buyButton.SetActive(false);
        selectButton.SetActive(true);
        colorButton.SetActive(true);
        rimButton.SetActive(true);
    }

    public void ChooseCarByButton(int counter)
    {
        FindObjectOfType<AudioManager>().playAudio("CarSelection");
        carCounter = counter;

        for (int i = 0; i < carButtons.Length; i++)
        {
            carModels[i].SetActive(false);
            carSpecs[i].SetActive(false);

            carButtons[i].transform.GetChild(0).transform.gameObject.SetActive(false);
            carButtons[i].transform.GetChild(1).transform.gameObject.SetActive(false);
            
            carButtons[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        carModels[carCounter - 1].SetActive(true);
        carSpecs[carCounter - 1].SetActive(true);


        if (PlayerPrefs.GetInt("Player" + (carCounter - 1)) == 1)
        {
            selectButton.SetActive(true);
            colorButton.SetActive(true);
            rimButton.SetActive(true);
            buyButton.SetActive(false);
            PlayerPrefs.SetInt("ActiveCar", (carCounter - 1));
            PlayerPrefs.SetString("CarName", carModels[carCounter - 1].name);
            carCounter = counter;

            SetCustomizationPlayerPref();

            carButtons[carCounter - 1].transform.GetChild(0).gameObject.SetActive(true);
            carButtons[carCounter - 1].transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            buyButton.SetActive(true);
            selectButton.SetActive(false);
            colorButton.SetActive(false);
            rimButton.SetActive(false);
            carButtons[carCounter - 1].transform.GetChild(0).gameObject.SetActive(false);
            carButtons[carCounter - 1].transform.GetChild(1).gameObject.SetActive(true);

            carButtons[PlayerPrefs.GetInt("ActiveCar")].transform.GetChild(0).transform.gameObject.SetActive(true);
            carButtons[PlayerPrefs.GetInt("ActiveCar")].transform.GetChild(1).transform.gameObject.SetActive(false);
        }

        
        carButtons[carCounter - 1].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void BuyCar()
    {
        if(PlayerPrefs.GetInt("Coins") >= carModelPrices[carCounter - 1] && PlayerPrefs.GetInt("Player" + (carCounter - 1)) != 1)
        {
            PlayerPrefs.SetInt("ActiveCar", (carCounter-1));
            PlayerPrefs.SetInt("Player" + (carCounter - 1), 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - carModelPrices[carCounter - 1]);

            SetCustomizationPlayerPref();

            buyButton.SetActive(false);
            selectButton.SetActive(true);
            colorButton.SetActive(true);
            rimButton.SetActive(true);

            for (int i = 0; i < carButtons.Length; i++)
            {
                carButtons[i].transform.GetChild(0).transform.gameObject.SetActive(false);
                carButtons[i].transform.GetChild(1).transform.gameObject.SetActive(false);
            }

            carButtons[carCounter-1].transform.GetChild(0).transform.gameObject.SetActive(true);
            carButtons[carCounter-1].transform.GetChild(1).transform.gameObject.SetActive(false);

        }
        else
        {
            carButtons[carCounter-1].transform.GetChild(0).transform.gameObject.SetActive(false);
            carButtons[carCounter-1].transform.GetChild(1).transform.gameObject.SetActive(true);
        }
    }

    void ControlsOnStart()
    {
        for (int i = 0; i < buttonControllers.Length; i++)
        {
            buttonControllers[i].GetComponent<Image>().sprite = UnSelectedControllers[i];
        }

        buttonControllers[PlayerPrefs.GetInt("Controller")].GetComponent<Image>().sprite = SelectedControllers[PlayerPrefs.GetInt("Controller")];
    }


    public void SetControlls(int index)
    {
        PlayerPrefs.SetInt("Controller", index);

        for (int i = 0; i < buttonControllers.Length; i++)
        {
            buttonControllers[i].GetComponent<Image>().sprite = UnSelectedControllers[i];
        }

        buttonControllers[PlayerPrefs.GetInt("Controller")].GetComponent<Image>().sprite = SelectedControllers[PlayerPrefs.GetInt("Controller")];
    }


    /// <summary>
    /// Customization of Car Color and Rims
    /// </summary>

    public void PaintColors(int colorNumber)
    {
        colorCounter = colorNumber;
        for (int i = 0; i < paintColorButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("PaintColor" + PlayerPrefs.GetString("CarName") + i) == carCounter)
            {
                paintColorButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                paintColorButtons[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                paintColorButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                paintColorButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                paintColorButtons[i].transform.GetChild(2).gameObject.SetActive(false);
            }
            paintColorButtons[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (PlayerPrefs.GetInt("PaintColor" + PlayerPrefs.GetString("CarName") + colorCounter) == carCounter)
        {
            if (PlayerPrefs.GetInt("CurrentPaint" + carCounter) == colorCounter)
            {
                paintColorButtons[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[colorCounter].transform.GetChild(1).gameObject.SetActive(true);
                paintColorButtons[colorCounter].transform.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                paintColorButtons[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[colorCounter].transform.GetChild(1).gameObject.SetActive(false);
                paintColorButtons[colorCounter].transform.GetChild(2).gameObject.SetActive(true);
            }
            paintColorButtons[colorCounter].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            if (PlayerPrefs.GetInt("CurrentPaint" + carCounter) == colorCounter)
            {
                equip.SetActive(false);
                equipped.SetActive(true);
                buy.SetActive(false);
            }
            else
            {
                equip.SetActive(true);
                equipped.SetActive(false);
                buy.SetActive(false);
            }
        }
        else
        {
            equip.SetActive(false);
            equipped.SetActive(false);
            buy.SetActive(true);
            paintColorButtons[colorCounter].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }

        CarPaintColor();
    }

    void PaintColorOnStart()
    {
        for (int i = 0; i < paintColorButtons.Length; i++)
        {

            if (PlayerPrefs.GetInt("PaintColor" + PlayerPrefs.GetString("CarName") + (i)) == carCounter)
            {

                paintColorButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                paintColorButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                paintColorButtons[i].transform.localScale = new Vector3(1f, 1f, 1f);

                paintColorButtons[PlayerPrefs.GetInt("CurrentPaint" + carCounter)].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[PlayerPrefs.GetInt("CurrentPaint" + carCounter)].transform.GetChild(1).gameObject.SetActive(true);
                paintColorButtons[PlayerPrefs.GetInt("CurrentPaint" + carCounter)].transform.GetChild(2).gameObject.SetActive(false);

                paintColorButtons[PlayerPrefs.GetInt("CurrentPaint" + carCounter)].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                CarPaintColorOnStart();
            }
            else
            {

                paintColorButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                paintColorButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                paintColorButtons[i].transform.GetChild(2).gameObject.SetActive(false);

                paintColorButtons[i].transform.localScale = new Vector3(1f, 1f, 1f);

            }

        }

    }





    void CarPaintColor()
    {
        Debug.Log(PlayerPrefs.GetInt("ActiveCar"));
        if (PlayerPrefs.GetInt("ActiveCar") == 0)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar1[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 1)
        {
            carMeshRenderer[carCounter -1 ].material = paintMaterialsCar2[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 2)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar3[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 3)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar4[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 4)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar5[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 5)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar6[colorCounter];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 6)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar7[colorCounter];
        }
    }

    void CarPaintColorOnStart()
    {
        if (PlayerPrefs.GetInt("ActiveCar") == 0)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar1[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 1)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar2[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 2)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar3[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 3)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar4[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 4)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar5[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 5)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar6[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
        if (PlayerPrefs.GetInt("ActiveCar") == 6)
        {
            carMeshRenderer[carCounter -1].material = paintMaterialsCar7[PlayerPrefs.GetInt("CurrentPaint" + carCounter)];
        }
    }

    public void ChooseRim(int modelNumber)
    {
        colorCounter = modelNumber;
        for (int i = 0; i < rimModelBtns.Length; i++)
        {
            if (PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + (i)) == carCounter)
            {
                rimModelBtns[i].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[i].transform.GetChild(1).gameObject.SetActive(false);
                rimModelBtns[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                rimModelBtns[i].transform.GetChild(0).gameObject.SetActive(true);
                rimModelBtns[i].transform.GetChild(1).gameObject.SetActive(false);
                rimModelBtns[i].transform.GetChild(2).gameObject.SetActive(false);

            }
            rimModelBtns[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + (colorCounter)) == carCounter)
        {
            if (PlayerPrefs.GetInt("RimModelCurrent" + carCounter) == colorCounter)
            {
                rimModelBtns[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[colorCounter].transform.GetChild(1).gameObject.SetActive(true);
                rimModelBtns[colorCounter].transform.GetChild(2).gameObject.SetActive(false);

            }
            else
            {
                rimModelBtns[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[colorCounter].transform.GetChild(1).gameObject.SetActive(false);
                rimModelBtns[colorCounter].transform.GetChild(2).gameObject.SetActive(true);

            }

            rimModelBtns[colorCounter].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

            if (PlayerPrefs.GetInt("RimModelCurrent" + carCounter) == colorCounter)
            {
                equip.SetActive(false);
                equipped.SetActive(true);
                buy.SetActive(false);
            }
            else
            {
                equip.SetActive(true);
                equipped.SetActive(false);
                buy.SetActive(false);
            }

        }
        else
        {
            equip.SetActive(false);
            equipped.SetActive(false);
            buy.SetActive(true);
            rimModelBtns[colorCounter].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        }

        CarRimModel();

    }

    void RimModelOnStart()
    {
        for (int i = 0; i < rimModelBtns.Length; i++)
        {
            if (PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + (i)) == carCounter)
            {
                rimModelBtns[i].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[i].transform.GetChild(1).gameObject.SetActive(false);
                rimModelBtns[i].transform.GetChild(2).gameObject.SetActive(true);
                rimModelBtns[i].transform.localScale = new Vector3(1f, 1f, 1f);

                rimModelBtns[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)].transform.GetChild(1).gameObject.SetActive(true);
                rimModelBtns[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)].transform.GetChild(2).gameObject.SetActive(false);

                rimModelBtns[PlayerPrefs.GetInt("RimModelCurrent" + carCounter)].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

                CarRimModelOnStart();
            }
            else
            {
                rimModelBtns[i].transform.GetChild(0).gameObject.SetActive(true);
                rimModelBtns[i].transform.GetChild(1).gameObject.SetActive(false);
                rimModelBtns[i].transform.GetChild(2).gameObject.SetActive(false);

                rimModelBtns[i].transform.localScale = new Vector3(1f, 1f, 1f);

            }

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


    void CarCustomizationOnStart()
    {
        CarPaintColorOnStart();
        CarRimModelOnStart();
    }


    /// <summary>
    /// Buying Cutomization
    /// </summary>
    /// 

    public void BuyCustomization()
    {

        if (colorCustomizationPanel.activeSelf)
        {
            if (PlayerPrefs.GetInt("Coins") >= 100 && PlayerPrefs.GetInt("PaintColor" + PlayerPrefs.GetString("CarName") + colorCounter) != carCounter)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
                PlayerPrefs.SetInt("CurrentPaint" + carCounter, colorCounter);
                PlayerPrefs.SetInt("PaintColor" + PlayerPrefs.GetString("CarName") + colorCounter, carCounter);

                paintColorButtons[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[colorCounter].transform.GetChild(1).gameObject.SetActive(true);
                paintColorButtons[colorCounter].transform.GetChild(2).gameObject.SetActive(false);

                equip.SetActive(false);
                equipped.SetActive(true);
                buy.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("PaintColor" + PlayerPrefs.GetString("CarName") + colorCounter) == carCounter && PlayerPrefs.GetInt("CurrentPaint" + carCounter) != colorCounter)
            {
                PlayerPrefs.SetInt("CurrentPaint" + carCounter, colorCounter);
                paintColorButtons[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                paintColorButtons[colorCounter].transform.GetChild(1).gameObject.SetActive(true);
                paintColorButtons[colorCounter].transform.GetChild(2).gameObject.SetActive(false);

                equip.SetActive(false);
                equipped.SetActive(true);
                buy.SetActive(false);

                CarPaintColorOnStart();
            }
        }
        if (rimCustomizationPanel.activeSelf)
        {
            if (PlayerPrefs.GetInt("Coins") >= 100 && PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + colorCounter) != carCounter)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
                PlayerPrefs.SetInt("RimModelCurrent" + carCounter, colorCounter);
                PlayerPrefs.SetInt("RimModel" + PlayerPrefs.GetString("CarName") + colorCounter, carCounter);

                Debug.Log(PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + colorCounter));

                rimModelBtns[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[colorCounter].transform.GetChild(1).gameObject.SetActive(true);
                rimModelBtns[colorCounter].transform.GetChild(2).gameObject.SetActive(false);

                equip.SetActive(false);
                equipped.SetActive(true);
                buy.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + colorCounter) == carCounter && PlayerPrefs.GetInt("RimModelCurrent" + carCounter) != colorCounter)
            {
                PlayerPrefs.SetInt("RimModelCurrent" + carCounter, colorCounter);
                rimModelBtns[colorCounter].transform.GetChild(0).gameObject.SetActive(false);
                rimModelBtns[colorCounter].transform.GetChild(1).gameObject.SetActive(true);
                rimModelBtns[colorCounter].transform.GetChild(2).gameObject.SetActive(false);

                equip.SetActive(false);
                equipped.SetActive(true);
                buy.SetActive(false);

                CarRimModelOnStart();
            }
        }

    }

    void PlayerPrefInitialization()
    {
        if(!PlayerPrefs.HasKey("ActiveCar"))
        {
            PlayerPrefs.SetInt("ActiveCar", 0);
        }

        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 500);
        }

        for (int i = 1; i < carModels.Length; i++)
        {
            if (!PlayerPrefs.HasKey("Player" + i))
            {
                PlayerPrefs.SetInt("Player" + i,0);
            }
        }

        if (!PlayerPrefs.HasKey("Player0"))
        {
            PlayerPrefs.SetInt("Player0", 1);
        }
        
        if (!PlayerPrefs.HasKey("ChapterOneLevelUnlock"))
        {
            PlayerPrefs.SetInt("ChapterOneLevelUnlock", 0);
        }
        

        if(!PlayerPrefs.HasKey("SoundSliderValue"))
        {
            PlayerPrefs.SetFloat("SoundSliderValue", 0.5f);
        }
        
        if(!PlayerPrefs.HasKey("MusicSliderValue"))
        {
            PlayerPrefs.SetFloat("MusicSliderValue", 0.5f);
        }
        
        if(!PlayerPrefs.HasKey("Controller"))
        {
            PlayerPrefs.SetInt("Controller", 2); 
        }



       
    }


    void SetCustomizationPlayerPref()
    {
        if (PlayerPrefs.GetInt("PaintColor" + PlayerPrefs.GetString("CarName") + "0") != carCounter)
        {
            PlayerPrefs.SetInt("PaintColor" + PlayerPrefs.GetString("CarName") + "0", carCounter);
        }


        if (PlayerPrefs.GetInt("RimModel" + PlayerPrefs.GetString("CarName") + "0") != carCounter)
        {
            PlayerPrefs.SetInt("RimModel" + PlayerPrefs.GetString("CarName") + "0", carCounter);
        }

    }
}
