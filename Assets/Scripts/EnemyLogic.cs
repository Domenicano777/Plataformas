using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float enemySpeed;
    public float limiteR;
    public float limiteL;
    public bool moveRight;
    Puntuacion p;

    private void Start()
    {
        p = FindAnyObjectByType<Puntuacion>();
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);

            if (transform.position.x >= limiteR)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);

            if (transform.position.x <= limiteL)
            {
                moveRight = true;
            }
        }      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            p.lives--;
        }
    }
}
