using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	public int maxHP = 100;
	public float walkSpeed = 3f;
	public float runSpeed = 8f;
	
	private float HP;
	private Vector3 velocity = new Vector3(0f, 0f, 0f);
	private Animator animator;
	
	void Start() {
		animator = gameObject.GetComponent<Animator>();
		walkSpeed /= 100; // divide by pixels per unit
		runSpeed /= 100;  // to keep things from getting cuhrayzee
	}

	void Update() {
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		input = Vector2.ClampMagnitude(input, 1);

		if (Input.GetAxis("Run") > 0) {
			velocity.x = input.x * runSpeed;
			velocity.y = input.y * runSpeed;
		} else {
			velocity.x = input.x * walkSpeed;
			velocity.y = input.y * walkSpeed;
		}

		/* sets the direction we're walking for the state machine
		 * 0 left
		 * 1 up
		 * 2 right
		 * 3 down
		 */
		if (velocity.x - Mathf.Abs(velocity.y) > 0) {
			animator.SetInteger("WalkingDir", 2);
		} else if (velocity.x + Mathf.Abs(velocity.y) < 0) {
			animator.SetInteger("WalkingDir", 0);
		} else if (velocity.y < 0) {
			animator.SetInteger("WalkingDir", 3);
		} else if (velocity.y > 0) {
			animator.SetInteger("WalkingDir", 1);
		}

		animator.SetBool("IsMoving", (velocity.x != 0)||(velocity.y != 0));

		//rigidbody2D.velocity += velocity;
	}

	void FixedUpdate() {
		transform.position += velocity;
	}
}
