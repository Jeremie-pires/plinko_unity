using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    public TextMeshProUGUI textComposant;
    private int scoreTotal = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        MettreAJourUI();
    }

    public void ModifierScore(int points)
    {
        scoreTotal += points;
        MettreAJourUI();
    }

    void MettreAJourUI()
    {
        textComposant.text = "Score : " + scoreTotal;
    }
}