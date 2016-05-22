using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float fallSpeed;
    public GameObject ground;

    private bool grounded = true;
    private bool attacking = false;
    private Rigidbody2D rigid;
    private BoxCollider2D box;
    private BoxCollider2D other;
    

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        box = gameObject.GetComponentInChildren<BoxCollider2D>();
        ground = gameObject.GetComponent<GameObject>();
        other = ground.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(rigid.velocity.y == 0) { grounded = true; }

        // print(grounded);

        float h = Input.GetAxis("Horizontal");

        transform.Translate (Vector2.right * h * speed / 5);

        if(Input.GetButtonDown("Jump") && grounded) {
            rigid.AddForce(new Vector2(0, jumpPower));
            grounded = false;
        }

    }

    public bool GetGrounded() {
        return grounded;
    }
    public float GetSpeed() {
        return speed;
    }
    public float GetAirSpeed() {
        return rigid.velocity.y;
    }
    public bool GetAttack() {
        return attacking;
    }

    private bool OnTriggerEnter2D(Collider2D other) {
        return box.IsTouching(other);
    }
}
