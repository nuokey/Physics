using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool cursorGravitation;
    public Rigidbody2D rb;

    private float CursorGravitationForce = 25f;
    private float CursorGravitationTorque = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cursorGravitation = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            cursorGravitation = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        var position = Camera.main.ScreenToWorldPoint(mousePos);

        var heading = position - transform.position;

        if (cursorGravitation && heading.magnitude > 0.5f)
        {
            rb.AddForce(heading.normalized * CursorGravitationForce / (heading.magnitude * heading.magnitude));

            if (heading.x > 0)
            {
                rb.AddTorque(CursorGravitationTorque / (heading.y * heading.y));
            }

            // var heading = 
        }
    }
}
