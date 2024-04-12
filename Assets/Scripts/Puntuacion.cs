using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public int coins;
    public bool iHaveAllCoins = false;

    public TMP_Text coinsText;

    public GameObject victoria;
    public GameObject derrota;

    private void Start()
    {
        victoria.SetActive(false);
        derrota.SetActive(false); ;
    }

    private void Update()
    {
        coinsText.text = coins.ToString();
    }
}
