using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int Hits { get; set; }
    public int TotalTargets { get; set; }
    public float totalTime;
    private float currTime;
    public bool gameOver = false;
    private float hitPercentage = 0;
    public int LeftSideTargets { get; set; }
    public int RightSideTargets { get; set; }
    public int TopSideTargets { get; set; }
    public int DownSideTargets { get; set; }
    public bool startGame;

    public RawImage gameOverBG;
    public Image timeLimitSetter;
    public InputField timeLimitInput;
    public TextMeshProUGUI hitPercentageText;
    public TextMeshProUGUI hitText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalTargetsText;
    public TextMeshProUGUI hitsByUserText;
    
    void Start()
    {
        Hits = 0;
        gameOverBG.gameObject.SetActive(false);
        timeLimitSetter.gameObject.SetActive(true);
        hitText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && startGame)
        {
            UpdateHitsUI();
            currTime -= Time.deltaTime;
            UpdateTime();
            if (gameOverBG.gameObject.activeSelf) gameOverBG.gameObject.SetActive(false);
        }
        if ((int)currTime <= 0 && !gameOver && startGame)
        {
            currTime = 0;
            UpdateTime();
            gameOver = true;
            HandleGameOver();
        }
    }

    public void TakeMaxTimeInput()
    {
        totalTime = int.Parse(timeLimitInput.text);
        currTime = totalTime;
        timeLimitSetter.gameObject.SetActive(false);
        hitText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        startGame = true;
    }

    public void HandleGameOver()
    {
        timeText.gameObject.SetActive(false);
        hitText.gameObject.SetActive(false);
        gameOverBG.gameObject.SetActive(true);
        hitPercentage = ((float)Hits / TotalTargets) * 100f;
        hitPercentageText.SetText("Accuracy : " + System.Math.Round(hitPercentage,2) + "%");
        hitsByUserText.SetText("Total Hits : " + Hits);
        totalTargetsText.SetText("Total Targets : " + TotalTargets);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        startGame = false;
        //timeText.gameObject.SetActive(true);
        //hitText.gameObject.SetActive(true);
        //currTime = totalTime;
        TotalTargets = 0;
        Hits = 0;
        gameOver = false;
        gameOverBG.gameObject.SetActive(false);
        timeLimitSetter.gameObject.SetActive(true);
    }
    public void IncrementHits()
    {
        Hits++;
    }
    public void IncrementTotalTargets()
    {
        TotalTargets++;
    }

    void UpdateHitsUI()
    {
        hitText.SetText( "Hits " + Hits);
    }

    void UpdateTime()
    {
        timeText.SetText("Time Remaining : " + (int)currTime + " s");
    }
}
