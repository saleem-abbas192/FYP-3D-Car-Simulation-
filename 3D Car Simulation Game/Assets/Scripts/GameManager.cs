using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject gameCompletePanel;
    public GameObject gameFailedPanel;
    public GameObject gamePausePanel;
    public GameObject loadingPanel;

    public Transform[] carPositions;

    public GameObject[] levels;

    public Rigidbody rcc_rig;
    
    public int levelNo;

    [Header("Hits Managment")]
    public int collisionCount;
    public Text levelFailedHits;
    public Text levelCompleteHits;
    public Text gamePlayHits;

    [Header("Time Managment")]
    public float timeLimit; 
    public float timeRemaining;
    TimeSpan timePlaying;
    float elapsedTime;
    bool timerGoing;
    public bool timeStartedInGamePlay;
    public Text timeText;
    public Text levelCompleteText;
    public Text levelFailedText;

    [Header("Medals Managment")]
    public GameObject medal;
    public GameObject star1, star2, star3;

    [Header("Sound Managment")]
    public Slider musicSlider;
    public Slider soundSlider;

    [Header("Camera Managment")]
    public bool canmHandle;
    bool once;

    [Header("Pause Controlls")]
    public Image[] buttonControllers;
    public Sprite[] UnSelectedControllers;
    public Sprite[] SelectedControllers;

    public CarCustomizationCall carCustomizaionCall;
    public static GameManager instance;
    void Start()
    {
        instance = this;
        levelNo = MenuManager.instance.levelNo;

        rcc_rig = CarCustomizationCall.instance.CarModels[PlayerPrefs.GetInt("ActiveCar")].GetComponent<Rigidbody>();
        CarOnStart();
        LevelOnStart();
        HideAllPanels();
        ControlsOnStart();

        soundSlider.value = PlayerPrefs.GetFloat("SoundSliderValue");
        musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue");

        once = true;

        //BeginTimer(0);
        timeLimit = 120.0f;
        //timeStartedInGamePlay = true;
        timeRemaining = timeLimit;
        UpdateTimeTextInGamePlay();

    }

    
    void Update()
    {
        PlayerPrefs.SetFloat("SoundSliderValue", soundSlider.value);
        PlayerPrefs.SetFloat("MusicSliderValue", musicSlider.value);
        gamePlayHits.text = collisionCount.ToString() + "/3";

        if (timeRemaining > 0.0f && timeStartedInGamePlay == true)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeTextInGamePlay();
        }
        if(timeRemaining <= 0.0f)
        {
            GameFailed();
        }

    }

    void CarOnStart()
    {
        for (int i = 0; i < CarCustomizationCall.instance.CarModels.Length; i++)
        {
            CarCustomizationCall.instance.CarModels[i].SetActive(false);
        }
        CarCustomizationCall.instance.CarModels[PlayerPrefs.GetInt("ActiveCar")].SetActive(true);
        CarCustomizationCall.instance.CarModels[PlayerPrefs.GetInt("ActiveCar")].transform.SetPositionAndRotation(carPositions[levelNo].position, carPositions[levelNo].rotation);
    }

    void LevelOnStart()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        levels[levelNo].SetActive(true);
    }

    public void GameFailed()
    {
        if (once)
        {
            FindObjectOfType<AudioManager>().playAudio("Game Failed");
            HideAllPanels();
            EndTimer();
            levelFailedHits.text = collisionCount.ToString();
            rcc_rig.constraints = RigidbodyConstraints.FreezeAll;
            loadingPanel.SetActive(true);
            Invoke("GameFailedHandle", 2f);
            once = false;
        }

    }

    void GameFailedHandle()
    {
        HideAllPanels();
        gameFailedPanel.SetActive(true);
    }


    public void GameComplete()
    {
        EndTimer();
        HideAllPanels();
        levelCompleteHits.text = collisionCount.ToString();
        rcc_rig.constraints = RigidbodyConstraints.FreezeAll;
        loadingPanel.SetActive(true);

        if (PlayerPrefs.GetInt("ChapterOneLevelUnlock") <= MenuManager.instance.levelNo && MenuManager.instance.levelNo != 36)
        {
            PlayerPrefs.SetInt("ChapterOneLevelUnlock", PlayerPrefs.GetInt("ChapterOneLevelUnlock") + 1);
        }
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 300);
       

        Invoke("GameCompleteHandle", 2f);
        
    }

    void GameCompleteHandle()
    {
        HideAllPanels();
        MedalManagement();
        if(collisionCount == 0)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if(collisionCount == 1)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (collisionCount == 2)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        gameCompletePanel.SetActive(true);
    }


    public void GamePause()
    {
        EndTimer();
        HideAllPanels();
        timeStartedInGamePlay = false;
        rcc_rig.constraints = RigidbodyConstraints.FreezeAll;
        loadingPanel.SetActive(true);

        Invoke("PauseHandle", 2f);
    }

    void PauseHandle()
    {
        HideAllPanels();
        gamePausePanel.SetActive(true);
    }

    public void Home()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        CamHandle();
        loadingPanel.SetActive(true);
        rcc_rig.constraints = RigidbodyConstraints.None;

        StartCoroutine(HomeHandle());
        

    }

    IEnumerator HomeHandle()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        rcc_rig.constraints = RigidbodyConstraints.None;
        BeginTimer(elapsedTime);
        timeStartedInGamePlay = true;
        HideAllPanels();
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        CamHandle();
        loadingPanel.SetActive(true);
        Invoke("RestartHandle", 2f);

    }

    void RestartHandle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        CamHandle();
        gameCompletePanel.SetActive(false);
        
        LevelHandleHelper();
        
    }

    void LevelHandleHelper()
    {
        MenuManager.instance.levelNo += 1;
        levelNo = MenuManager.instance.levelNo;
        loadingPanel.SetActive(true);
        
        if (levelNo >= 40)
        {
            loadingPanel.SetActive(true);
            SceneManager.LoadScene(1);
        }
        else if ((levelNo >= 0 && levelNo <= 8) || (levelNo >= 10 && levelNo <= 18) || (levelNo >= 20 && levelNo <= 28) || (levelNo >= 30 && levelNo <= 38))
        {
            StartCoroutine(LevelHandler());
        }
        else if (levelNo == 9 || levelNo == 19 || levelNo == 29 || levelNo == 39)
        {
            StartCoroutine(LevelQuizHandler());
        }
        
    }

    IEnumerator LevelQuizHandler()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(3);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LevelHandler()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    void HideAllPanels()
    {
        gameCompletePanel.SetActive(false);
        gameFailedPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        loadingPanel.SetActive(false);
    }


    void UpdateTimeTextInGamePlay()
    {
        if(timeStartedInGamePlay)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60.0f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60.0f);
            string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            timeText.text = formattedTime;
        }
    }


    public void BeginTimer(float timeSaved)
    {
        timerGoing = true;
        elapsedTime = timeSaved;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            levelCompleteText.text = timePlayingStr;
            levelFailedText.text = timePlayingStr;

            yield return null;
        }
    }

    void MedalManagement()
    {
        if(collisionCount >= 0 && collisionCount <= 1)
        {
            medal.transform.GetChild(0).gameObject.SetActive(true);
            medal.transform.GetChild(1).gameObject.SetActive(false);
            medal.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if(collisionCount > 1 && collisionCount <= 2)
        {
            medal.transform.GetChild(0).gameObject.SetActive(false);
            medal.transform.GetChild(1).gameObject.SetActive(true);
            medal.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if(collisionCount > 2 && collisionCount <= 3)
        {
            medal.transform.GetChild(0).gameObject.SetActive(false);
            medal.transform.GetChild(1).gameObject.SetActive(false);
            medal.transform.GetChild(2).gameObject.SetActive(true);
        }
    }


    public void setControlls(int index)
    {
        PlayerPrefs.SetInt("Controller", index);

        for (int i = 0; i < buttonControllers.Length; i++)
        {
            buttonControllers[i].GetComponent<Image>().sprite = UnSelectedControllers[i];
        }

        buttonControllers[PlayerPrefs.GetInt("Controller")].GetComponent<Image>().sprite = SelectedControllers[PlayerPrefs.GetInt("Controller")];

        RCC_Demo.SetMobileController(PlayerPrefs.GetInt("Controller"));
    }

    void ControlsOnStart()
    {
        for (int i = 0; i < buttonControllers.Length; i++)
        {
            buttonControllers[i].GetComponent<Image>().sprite = UnSelectedControllers[i];
        }

        buttonControllers[PlayerPrefs.GetInt("Controller")].GetComponent<Image>().sprite = SelectedControllers[PlayerPrefs.GetInt("Controller")];

        RCC_Demo.SetMobileController(PlayerPrefs.GetInt("Controller"));
    }

    public void CamHandle()
    {
        canmHandle = true;
        FindObjectOfType<RCC_Camera>().ChangeCamera();

    }
}
