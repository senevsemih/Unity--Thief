using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public static MoneyCounter instance;

    [Header("References")]
    public TMP_Text moneyText;
    public TMP_Text scoreText;

    private int score;

    void Start()
    {
        if(instance == null)
            instance = this;
    }
    public void TotalMoney(int value)
    {
        score += value;

        moneyText.text = score.ToString() + " $";

        scoreText.text = "Total :  " + score.ToString() + "  $ ";
    }
}
