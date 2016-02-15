using UnityEngine;
using System.Collections;

public class Bee : MonoBehaviour {

	public Player target;

	public float LocatingSpeed;
	public float AttackingSpeed;
	public float RoamingSpeed;
	public float ChargingSpeed;
	public State state;

	public float IdleDistance;

	public float HoverRangeFromPlayer;
	public float HoverDistance;
	public float AttackScale;

	public float TimeBetweenAttacks;
	public float AttackChargeUp;

	int direction;
	float lastAttack;
	Vector3 attackTarget;
	float chargeStart;


	void Start () {
		direction = 1;
		state = State.Idle;
	}

	void Update () {
		switch (state) {
		case State.Attacking:
			transform.position = Vector3.MoveTowards (transform.position, attackTarget, AttackingSpeed);
			transform.localScale += Vector3.up * AttackScale + Vector3.right * AttackScale; 
			if (transform.position == attackTarget) {
				state = State.Locating;
				transform.localScale = Vector3.one;
			}
			break;
		case State.Charging:
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, ChargingSpeed *-1);
			if (Time.time - chargeStart > AttackChargeUp) {
				state = State.Attacking;

			}
			break;
		case State.Idle:
			if (Vector2.Distance(transform.position, target.transform.position) < IdleDistance) {
				state = State.Locating;
			}
			break;
		case State.Locating:
			if (Vector2.Distance(transform.position, target.transform.position) > IdleDistance) {
				state = State.Idle;
				break;
			}
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position + Vector3.up * HoverRangeFromPlayer, LocatingSpeed);
			if (transform.position == target.transform.position + Vector3.up * HoverRangeFromPlayer) {
				state = State.Roaming;
				lastAttack = Time.time;
			}
			break;
		case State.Roaming:
			float distance = Vector2.Distance (transform.position, target.transform.position + Vector3.up * HoverRangeFromPlayer);
			if (distance > IdleDistance) {
				state = State.Idle;
				break;
			}
			if (distance > HoverDistance) {
				direction *= -1;
			}
			if (Time.time - lastAttack > TimeBetweenAttacks) {
				state = State.Charging;
				chargeStart = Time.time;
				attackTarget = target.transform.position;
			}
			transform.position += new Vector3 (1 * RoamingSpeed * direction, 0, 0);
			break;
		default:
			break;
		}
	}

	public enum State{
		Idle,
		Locating,
		Roaming,
		Charging,
		Attacking
	}
}
