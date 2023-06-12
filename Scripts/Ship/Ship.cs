using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // variables for positions
    private Vector2 worldMousePos;
    // ship state variables
    private float angle;
    public float momentumChange = 0.1f;
    // ship speed
    private Vector3 velocity;

    public ParticleSystem shipExhaust;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var em = shipExhaust.emission;

        if (Input.GetMouseButton(0))
        {
            em.enabled = true;
            gainMomentum();
        }

        else
        {
            em.enabled = false;
        }
        moveShip();
        lookAtMouse();
    }

    private void lookAtMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        angle = -Vector2.SignedAngle(worldMousePos - (Vector2)transform.position, transform.up);
        transform.eulerAngles += new Vector3 (0.0f, 0.0f, angle);
    }

    private void moveShip()
    {
        transform.position += velocity*Time.deltaTime;
    }

    private void gainMomentum()
    {
        velocity += transform.up * momentumChange * Time.deltaTime;
    }
}
