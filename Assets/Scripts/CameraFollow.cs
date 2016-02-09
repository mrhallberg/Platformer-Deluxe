using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public Vector2 focusAreaSize;
	public float verticalOffset;

//	public float lookAheadDistanceX;
//	public float lookSmoothTimeX;
//	public float verticalSmoothTime;
//	float currentLookAheadX;
//	float targetLookAheadX;
//	float lookAheadDirectionX;
//	float smoothLookVelocityX;
//	float smoothVelocityY;

	FocusArea focusArea;

	void Start(){
		focusArea = new FocusArea (target, focusAreaSize);
	}

	void LateUpdate(){
		focusArea.Update (target);

		Vector2 focusPosition = focusArea.centre + Vector2.up * verticalOffset;
//		if (focusArea.velocity.x != 0) {
//			lookAheadDirectionX = Mathf.Sign (focusArea.velocity.x);
//		}
//		targetLookAheadX = lookAheadDirectionX * lookAheadDistanceX;
//		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);
//		focusPosition += Vector2.right * currentLookAheadX;

		transform.position = (Vector3)focusPosition + Vector3.forward * -10;
	}

	struct FocusArea{
		public Vector2 centre;
		public Vector2 velocity;
		public Bounds target;
		float left, right;
		float top, bottom;

		public FocusArea(GameObject t, Vector2 size){
			target = new Bounds(t.transform.position, size);

			left = target.center.x - size.x/2;
			right = target.center.x + size.x/2;
			bottom = target.min.y;
			top = target.min.y + size.y;

			velocity = Vector2.zero;
			centre = new Vector2((left+right)/2, (top+bottom)/2);
		}

		public void Update(GameObject target){
			float shiftX = 0;
			if (target.transform.position.x < left) {
				shiftX = target.transform.position.x - left;
			}
			else if (target.transform.position.x > right) {
				shiftX = target.transform.position.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (target.transform.position.y < bottom) {
				shiftY = target.transform.position.y - bottom;
			}
			else if (target.transform.position.y > top) {
				shiftY = target.transform.position.y - top;
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2((left+right)/2, (top+bottom)/2);
			velocity = new Vector2 (shiftX, shiftY);
		}
	}
}
