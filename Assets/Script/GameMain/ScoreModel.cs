using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel
{
    private int m_Score;

    public string Rank => "SSS";
    public int Score => m_Score;


    public void AddScore(int score) => m_Score += score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
