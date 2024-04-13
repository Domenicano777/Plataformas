using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public int coins;
    public int lives;
    public bool iHaveAllCoins = false;

    public TMP_Text coinsText;
    public TMP_Text livesText;

    private void Update()
    {
        coinsText.text = coins.ToString();
        livesText.text = lives.ToString();

        if (coins == 5)
        {
            iHaveAllCoins = true;
        }
    }
}
