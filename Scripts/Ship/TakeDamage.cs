using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private CircleCollider2D col;
    public LayerMask predatorLayer;
    public int health;
    public TMPro.TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;

        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(transform.position, col.radius, predatorLayer);
        foreach (Collider2D c in contextColliders)
        {
            health--;
        }

        Death();
    }

    private void Death()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
