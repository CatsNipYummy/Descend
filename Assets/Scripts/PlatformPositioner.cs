using UnityEngine;
using System.Collections;

public class PlatformPositioner {

	private static float m_fLeftAnchor;
	private static float m_fRightAnchor;

	public PlatformPositioner() {
		m_fLeftAnchor = 0.0f;
		m_fRightAnchor = 0.0f;

	}

	// Align Left
	private static void alignLeft() {
		Vector3 leftEndVector = Camera.main.ScreenToWorldPoint(Vector3.zero);
		m_fLeftAnchor = leftEndVector.x;
	}

	// Align Right
	private static void alignRight() {
		Vector3 rightEndVector = Camera.main.ViewportToWorldPoint(Vector3.one);
		GameObject childPlatform = GameObject.Find("PrototypeWhite04x01");
		float childPlatformX = childPlatform.GetComponent<SpriteRenderer>().bounds.size.x * 2;
		
		m_fRightAnchor = rightEndVector.x - childPlatformX;
	}


	// Getter
	public static float getLeftAnchor() {
		alignLeft();

		return m_fLeftAnchor;
	}

	public static float getRightAnchor() {
		alignRight();

		return m_fRightAnchor;
	}
}
