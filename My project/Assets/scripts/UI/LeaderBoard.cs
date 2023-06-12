using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public TextMeshProUGUI Text;

    private List<int> scores = new List<int>(); // List to store the scores

    void Start()
    {
        ReadScoresFromFile();
        SortScoresDescending();
        PrintScores();
    }

    void ReadScoresFromFile()
    {
        string[] lines = File.ReadAllLines("Assets/scripts/Player/score.txt");

        foreach (string line in lines)
        {
            int score;
            if (int.TryParse(line, out score))
            {
                scores.Add(score);
            }
        }
    }

    void SortScoresDescending()
    {
        scores = scores.Distinct().ToList();
        scores = scores.OrderByDescending(score => score).ToList();
    }

    void PrintScores()
    {
        foreach (int score in scores)
        {
            Debug.Log(score);
        }
    }

    void LeaderBoardFill()
    {
        if (scores.Count >= 3)
        {
            Text.text = "1. " + scores[0] + "\n2. " + scores[1] + "\n3. " + scores[2];
        }
        else if (scores.Count == 2)
        {
            Text.text = "1. " + scores[0] + "\n2. " + scores[1];
        }
        else if (scores.Count == 1)
        {
            Text.text = "1. " + scores[0];
        }
        else
        {
            Text.text = "No scores available.";
        }
    }

    private void Update()
    {
        LeaderBoardFill();
    }
}
