using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BallMovement : MonoBehaviour {

    public float waveR = 2.0f; // Radius of the wave
    public EventSystem eventSystem; 
    public GameObject ripple; // ripple prefab

    private PolygonCollider2D polyColli; // water collider
    private GameObject ball;

	// Use this for initialization
	void Start () {
        // Getting Collider
        polyColli = this.gameObject.GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // When clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Make sure click on UI won't affect gameplau
            if (eventSystem.IsPointerOverGameObject())
            {
                // Do nothing
            }
            else
            {
                Vector3 mouseRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // If the mouse click is on water
                if (polyColli.OverlapPoint(mouseRay))
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                    Instantiate(ripple, new Vector3(pos.x, pos.y, - 0.01f), Quaternion.Euler(0, 0, 0));

                    Collider2D[] colli = Physics2D.OverlapCircleAll(new Vector2(pos.x, pos.y), waveR);

                    // Get the ball object if it is within the wave radius
                    for (int i = 0; i < colli.Length; i++)
                    {
                        if (colli[i].tag == "ball")
                        {
                            ball = colli[i].gameObject;
                        }
                    }

                    // If ball is not null, get click position and ball position and apply force according to distance between them
                    if (ball != null)
                    {
                        Vector2 relativePos = new Vector2(pos.x - ball.transform.position.x, pos.y - ball.transform.position.y);
                        float distance = (float)Math.Pow((Math.Pow(relativePos.x, 2) + Math.Pow(relativePos.y, 2)), 0.5);
                        if (waveR > distance)
                        {
                            ball.GetComponent<Rigidbody2D>().AddForce((-relativePos / distance) * (waveR - distance) * 100); // unit vector * distance modifier * speed
                        }
                    }
                }
            }
        }
    }
}
