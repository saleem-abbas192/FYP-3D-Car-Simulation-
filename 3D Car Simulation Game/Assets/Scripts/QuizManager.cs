using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QnA1;
    public List<QuestionAnswer> QnA2;
    public List<QuestionAnswer> QnA3;
    public List<QuestionAnswer> QnA4;

    public GameObject[] options;
    public int currentQuestion;
    public Image questionImg;
    public Text questionText;

    public GameObject IntroPanel;
    public GameObject QuizPanel;
    public GameObject GameOverPanel;
    public GameObject loadingPanel;
    public GameObject NextButton;


    public Text correctAnswersCountText;
    public Text wrongAnswersCountText;
    public Text ScoreText;



    public Text QuizTitle;

    int totalQuestions = 0;
    public int scoreCount = 0;

    private void Start()
    {
        if(MenuManager.instance.levelNo == 9)
        {
            QuizTitle.text = "Quiz 1";
            totalQuestions = QnA1.Count;
        }
        else if (MenuManager.instance.levelNo == 19)
        {
            QuizTitle.text = "Quiz 2";
            totalQuestions = QnA2.Count;
        }
        else if (MenuManager.instance.levelNo == 29)
        {
            QuizTitle.text = "Quiz 3";
            totalQuestions = QnA3.Count;
        }
        else if (MenuManager.instance.levelNo == 39)
        {
            QuizTitle.text = "E-Licance (Grand Test)";
            totalQuestions = QnA4.Count;
        }

        DisableAllPanel();
        IntroPanel.SetActive(true);
    }
    public void TapToStartQuiz()
    {
        DisableAllPanel();
        QuizPanel.SetActive(true);
        GenerateQuestion();
    }

    void DisableAllPanel()
    {
        QuizPanel.SetActive(false);
        loadingPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        IntroPanel.SetActive(false);
    }

    public void NextLevel()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        DisableAllPanel();
        loadingPanel.SetActive(true);
        if (MenuManager.instance.levelNo >= 39)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            MenuManager.instance.levelNo += 1;
            StartCoroutine(NextLeveLoader());
        }
    }

    IEnumerator NextLeveLoader()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);
        while (!operation.isDone)
        {
            yield return null;
        }
    }


    public void Home()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        DisableAllPanel();
        loadingPanel.SetActive(true);

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



public void Restart()
    {
        FindObjectOfType<AudioManager>().playAudio("BackButtonClick");
        DisableAllPanel();
        loadingPanel.SetActive(true);
        Invoke("RestartHandle", 2f);

    }

    void RestartHandle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GameOver()
    {
        DisableAllPanel();
        GameOverPanel.SetActive(true);
        correctAnswersCountText.text = scoreCount.ToString();
        wrongAnswersCountText.text = (totalQuestions - scoreCount).ToString();
        ScoreText.text = scoreCount + "/" + totalQuestions;

        if(scoreCount != totalQuestions)
        {
            NextButton.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("ChapterOneLevelUnlock") <= MenuManager.instance.levelNo && MenuManager.instance.levelNo != 39)
            {
                PlayerPrefs.SetInt("ChapterOneLevelUnlock", PlayerPrefs.GetInt("ChapterOneLevelUnlock") + 1);
            }
        }
    }


    public void AnsweredQuestionCorrectly()
    {
        if (MenuManager.instance.levelNo == 9)
        {
            scoreCount++;
            QnA1.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
        else if (MenuManager.instance.levelNo == 19)
        {
            scoreCount++;
            QnA2.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
        else if (MenuManager.instance.levelNo == 29)
        {
            scoreCount++;
            QnA3.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
        else if (MenuManager.instance.levelNo == 39)
        {
            scoreCount++;
            QnA4.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
    }

    public void WronAnswered()
    {
        if (MenuManager.instance.levelNo == 9)
        {
            QnA1.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
        else if (MenuManager.instance.levelNo == 19)
        {
            QnA2.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
        else if (MenuManager.instance.levelNo == 29)
        {
            QnA3.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
        else if (MenuManager.instance.levelNo == 39)
        {
            QnA4.RemoveAt(currentQuestion);
            GenerateQuestion();
        }
    }


    void SetAnswers()
    {
        if (MenuManager.instance.levelNo == 9)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<Answers>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = QnA1[currentQuestion].Answers[i];

                if (QnA1[currentQuestion].CorrectAnswers == i + 1)
                {
                    options[i].GetComponent<Answers>().isCorrect = true;
                }
            }
        }
        else if (MenuManager.instance.levelNo == 19)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<Answers>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = QnA2[currentQuestion].Answers[i];

                if (QnA2[currentQuestion].CorrectAnswers == i + 1)
                {
                    options[i].GetComponent<Answers>().isCorrect = true;
                }
            }
        }
        else if (MenuManager.instance.levelNo == 29)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<Answers>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = QnA3[currentQuestion].Answers[i];

                if (QnA3[currentQuestion].CorrectAnswers == i + 1)
                {
                    options[i].GetComponent<Answers>().isCorrect = true;
                }
            }
        }
        else if (MenuManager.instance.levelNo == 39)
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<Answers>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<Text>().text = QnA4[currentQuestion].Answers[i];

                if (QnA4[currentQuestion].CorrectAnswers == i + 1)
                {
                    options[i].GetComponent<Answers>().isCorrect = true;
                }
            }
        }

    }



    void GenerateQuestion()
    {
        if(MenuManager.instance.levelNo == 9)
        {
            if (QnA1.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA1.Count);
                questionText.text = QnA1[currentQuestion].QuestionStr;
                questionImg.sprite = QnA1[currentQuestion].QuestionImg;

                SetAnswers();
            }
            else
            {
                Debug.Log("Out Of Question");
                GameOver();
            }
        }
        else if (MenuManager.instance.levelNo == 19)
        {
            if (QnA2.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA2.Count);
                questionText.text = QnA2[currentQuestion].QuestionStr;
                questionImg.sprite = QnA2[currentQuestion].QuestionImg;

                SetAnswers();
            }
            else
            {
                Debug.Log("Out Of Question");
                GameOver();
            }
        }
        else if (MenuManager.instance.levelNo == 29)
        {
            if (QnA3.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA3.Count);
                questionText.text = QnA3[currentQuestion].QuestionStr;
                questionImg.sprite = QnA3[currentQuestion].QuestionImg;

                SetAnswers();
            }
            else
            {
                Debug.Log("Out Of Question");
                GameOver();
            }
        }
        else if (MenuManager.instance.levelNo == 39)
        {
            if (QnA4.Count > 0)
            {
                currentQuestion = Random.Range(0, QnA4.Count);
                questionText.text = QnA4[currentQuestion].QuestionStr;
                questionImg.sprite = QnA4[currentQuestion].QuestionImg;

                SetAnswers();
            }
            else
            {
                Debug.Log("Out Of Question");
                GameOver();
            }
        }

    }  
}
