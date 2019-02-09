 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
     public SpriteRenderer note;
      public SpriteRenderer Suggest;
    bool Read = false;
	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Read) { note.enabled = true; Suggest.enabled = false; }
        if (Input.GetKeyUp(KeyCode.E) && note.enabled) note.enabled = false;
    }
        void OnTriggerEnter2D(Collider2D collider)
    { 
        Hero hero = collider.GetComponent<Hero>();
        if (hero && hero is Hero)
        {
            Suggest.enabled = true;
            Read = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Hero hero = collider.GetComponent<Hero>();
        if (hero && hero is Hero)
        {
            Suggest.enabled = false;
            note.enabled = false;
            Read = false;
        }
    }
}
