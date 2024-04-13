using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    Puntuacion pt;

    void Start()
    {
        pt = FindAnyObjectByType<Puntuacion>();
    }

  
    void Update()
    {
        if (pt.iHaveAllCoins == true)
        {
            transform.position = new Vector3(50.88f, 13, 0);
        }
    }
}
