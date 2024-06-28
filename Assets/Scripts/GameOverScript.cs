using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
       // Debug.Log("vgikaaaaaaaaaaaaaaa");
        gameObject.SetActive(true);
        pointsText.text = "Highest Block: " + score.ToString();

        //pointsText.text = "Highest Block: " + rowsInitiated.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("NewScene");

    }

    public void Exit()
    {
        Application.Quit();
    }
}
