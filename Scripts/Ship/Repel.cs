using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour
{
    public float maxRepelTime;
    private float repelTimer;
    public GameObject repelObj;
    private Renderer rd;
    public TMPro.TextMeshPro repelText;


    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Renderer>();
        repelTimer = maxRepelTime;
    }

    // Update is called once per frame
    void Update()
    {
        repelText.text = "Repel: " + (repelTimer).ToString("F2");

        if (Input.GetMouseButton(1) && repelTimer > 0)
        {
            repelObj.layer = LayerMask.NameToLayer("ShipRepel");
            repelTimer -= Time.deltaTime;
            rd.material.color = Color.green;
        }

        else if (repelTimer < maxRepelTime)
        {
            rd.material.color = Color.white;
            repelObj.layer = LayerMask.NameToLayer("Ship");
            repelTimer += Time.deltaTime;

            if (repelTimer > maxRepelTime)
            {
                repelTimer = maxRepelTime;
            }
        }
    }
}
