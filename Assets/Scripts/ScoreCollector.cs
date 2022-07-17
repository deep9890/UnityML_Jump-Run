using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using UnityEngine;


/*
 * Singleton to globally collect the Scores of all Players.
 * When a new Highscore is reached, it is added to Tensorboard.
 */
public class ScoreCollector : MonoBehaviour
{
    public static ScoreCollector Instance; 

    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshProUGUI currScoreUI;
    
    private StatsRecorder statsRecorder;
    private int highScore = 0;
    void Awake()
    {
        Instance = this;
        statsRecorder = Academy.Instance.StatsRecorder;
    }

    public void AddScore(int score)
    {
        currScoreUI.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScoreUI.text = score.ToString();
            statsRecorder.Add("High Score", highScore, StatAggregationMethod.MostRecent);
        }

    }
}
