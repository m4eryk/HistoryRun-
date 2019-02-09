using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAmmo : MonoBehaviour {
    public SpriteRenderer text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        text.enabled = true;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Hero>();
        if (unit && unit is Hero && Input.GetKeyDown(KeyCode.E))
        {
            unit.GetComponent<Hero>().Giveammo = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        text.enabled = false;
    }
}
