using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControler : MonoBehaviour {
    Animator anime;
    // Use this for initialization
    void Start()
    {
        
        anime = GetComponent<Animator>();
        IsplaneState = PlaneState.idle;
        StartCoroutine("GO");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public PlaneState IsplaneState
    {
        get { return (PlaneState)anime.GetInteger("State"); }
        set { anime.SetInteger("State", (int)value); }
    }
    IEnumerator GO()
    {
        yield return new WaitForSeconds(2f);
        IsplaneState = PlaneState.go;
    }
}
public enum PlaneState
{
    idle, //0
    go //1

}
