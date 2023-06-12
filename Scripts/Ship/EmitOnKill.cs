using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitOnKill : MonoBehaviour
{
    private CircleCollider2D col;
    public LayerMask defaultLayer;
    public ParticleSystem deathSystem;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(transform.position, col.radius, defaultLayer);
        foreach (Collider2D c in contextColliders)
        {
            Instantiate(deathSystem, c.transform.position, Quaternion.identity);
            c.gameObject.SetActive(false);
        }
    }
}
