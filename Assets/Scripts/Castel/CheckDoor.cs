using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoor : MonoBehaviour {
    Animator anime;
    public static bool OpenDoor { get; set; }

    // Use this for initialization
    void Start () {
        anime = GetComponent<Animator>();
        DoorState = DoorState.idle;
	}
	
	// Update is called once per frame
	void Update () {
        if (Gun.fullPornHub == 2)
        {
            StartCoroutine("Open");
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {   
    }
    public DoorState DoorState
    {
        get { return (DoorState)anime.GetInteger("State"); }
        set { anime.SetInteger("State", (int)value); }
    }
    IEnumerator Open()
    {
        yield return new WaitForSeconds(2f);
        DoorState = DoorState.open;
        OpenDoor = true;
    }
}
public enum DoorState
{
    idle, //0
    open //1
}
