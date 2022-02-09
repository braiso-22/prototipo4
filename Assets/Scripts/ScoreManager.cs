using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text roundText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        roundText.text = "ROUND: " + 0;
    }

    public void setRound(int ronda)
    {
        roundText.text = "ROUND: " + ronda;
    }
}
