using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wood : MonoBehaviour {
    public static bool Die { get; set; }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Hero>();
        if(unit && unit is Hero)
        {
            Die = true;
        }
    }
}
