using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
