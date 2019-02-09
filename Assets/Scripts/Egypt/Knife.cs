using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {


    private float spead= 5;
    private Vector3 direction;
    private SpriteRenderer sprite;
    public Vector3 Direction {  set { direction = value; } }
    GameObject parent;
    public GameObject Parent { set { parent = value; } }
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

    }
    void Start()
    {
        Destroy(gameObject, 1f);
    }
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
    }
}
