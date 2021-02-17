using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PostGameScript : MonoBehaviour
{
    [SerializeField]
    private GameObject postGamePanel;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private GameObject homeButton;

    // Start is called before the first frame update
    void Start()
    {
        postGamePanel.SetActive(false);
        GameEventsScript.defeat.AddListener(ShowLossPanel);
        GameEventsScript.victory.AddListener(ShowWinPanel);
    }

    private void ShowWinPanel()
    {
        postGamePanel.SetActive(true);
        text.GetComponent<Text>().text = "VICTORY!";
        playButton.SetActive(true);
    }

    private void ShowLossPanel()
    {
        postGamePanel.SetActive(true);
        text.GetComponent<Text>().text = "DEFEAT!";
        retryButton.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadSceneAsync(0);
        GameStateScript.IsGameOver = false;
        GameStateScript.IsPinMoving = false;
    }
}
