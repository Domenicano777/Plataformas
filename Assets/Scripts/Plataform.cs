using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public float platformSpeed;
    public float limiteR;
    public float limiteL;
    public bool moveRight;
    Player pl;

    private void Start()
    {
        pl = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * platformSpeed * Time.deltaTime);

            if (transform.position.x >= limiteR)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * platformSpeed * Time.deltaTime);

            if (transform.position.x <= limiteL)
            {
                moveRight = true;
            }
        }

        if (pl.imJumping == true)
        {
            pl.transform.SetParent(null);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
}
