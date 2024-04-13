using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    public float jumpForce = 10f; 
    public Rigidbody2D rb;
    public bool imJumping = false;

    [Header("Deteccion de suelo")]
    [Range(0f, 2f)]
    public float raycastDistance;
    public LayerMask layerMask;
    public bool grounded;

    [Header("Player attack")]
    public float attackRange;
    public int attackDamage;

    public List<Vector2> points;

    public Puntuacion pt;

    private void Start()
    {
        pt = FindAnyObjectByType<Puntuacion>();
    }
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            Attack();
        }
    }
    private void FixedUpdate()
    { 
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, 0);

        grounded = false;
        foreach (Vector2 p in points)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.up, raycastDistance, layerMask);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * raycastDistance, Color.red);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * hit.distance, Color.green);
            if (hit.collider != null)
            {
                grounded = true;
                imJumping = false;
            }
        }

        if (grounded == true && Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            imJumping = true;
        }

        if (pt.lives == 0)
        {
            pt.lives = 3;
            transform.position = new Vector3(-8.44f, -2.42f, 0);
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            pt.coins++;
        }
        if (collision.gameObject.CompareTag("DeathGround"))
        {
            transform.position = new Vector3(-8.44f, -2.42f, 0);
        }
    }
}
