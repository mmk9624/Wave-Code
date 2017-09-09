using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleTimer : MonoBehaviour {

    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
    // Play the ripple animation for 1 sec
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Destroy(this.gameObject);
        }
	}
}
