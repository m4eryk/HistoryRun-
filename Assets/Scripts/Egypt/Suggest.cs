using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suggest : MonoBehaviour {
    SpriteRenderer suggst;
    public int NamberSuggst;
    bool ExitLvl=false;
	// Use this for initialization
	void Start () {
        suggst = GetComponentInChildren<SpriteRenderer>();
	}
    void Update()
    {
        if (ChengeGoMove.Go && NamberSuggst == 1) { Destroy(gameObject); }
        if (Input.GetKeyDown(KeyCode.E) && ExitLvl) SceneManager.LoadScene("Castel");
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Hero)
        {
            Debug.Log("1");
            suggst.enabled = true;
        }
        if (NamberSuggst == 4) ExitLvl = true;
    }
}
