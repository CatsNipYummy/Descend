using UnityEngine;
using System.Collections;

public class LevelSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject robotCharacter;
	public GameObject door;
	public GameObject flames;

	public float flamesBeginAfter;
	public float timeBetweenFlames;
	public float numberOfPlatforms;

	private GameObject m_platformParent;

	private float m_fOrthographicSize = 5;
	private float m_fAspect = 1.33333f;

	private float m_fDistanceBetweenPlatform = 3.0f;

	private bool m_bIsRight = true;

	void Start () {
		// Force camera aspect ratio
		Camera.main.projectionMatrix = Matrix4x4.Ortho(
			-m_fOrthographicSize * m_fAspect, m_fOrthographicSize * m_fAspect,
			-m_fOrthographicSize, m_fOrthographicSize,
			Camera.main.nearClipPlane, Camera.main.farClipPlane);

		// Instantiate platforms
		createPlatforms();
	}

	void Awake () {
		InvokeRepeating("spawnFlames", flamesBeginAfter, timeBetweenFlames);
	}
	
	void Update () {
		// Follow camera linearly over Y-Axis
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, robotCharacter.transform.position.y, Camera.main.transform.position.z);
	}

	void createPlatforms() {
		// Reference to place next platform's Y
		float yPosition = platform.transform.position.y;
		
		// Instantiate the platforms
		m_platformParent = new GameObject("Platforms") as GameObject;
		for (int i = 1; i <= numberOfPlatforms; i++) {
			GameObject platformGameObject = Instantiate(platform) as GameObject;
			
			// Set position
			platformGameObject.transform.position = new Vector3(m_bIsRight ? PlatformPositioner.getLeftAnchor() : PlatformPositioner.getRightAnchor(), 
			                                            yPosition, 
			                                            platformGameObject.transform.position.z);
			// Alternate between left and right align
			m_bIsRight = !m_bIsRight;
			yPosition -= m_fDistanceBetweenPlatform;

			// Create exit door
			if (i == numberOfPlatforms) {
				createExitDoor(platformGameObject.transform.position);
			}

			// Clean Heirarchy
			platformGameObject.transform.SetParent(m_platformParent.transform);
		}	
	}

	void createExitDoor (Vector3 lastPlatformPosition) {
		GameObject doorGameObject = Instantiate(door);

		// Positioning the door
		lastPlatformPosition.x += doorGameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		lastPlatformPosition.y += doorGameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;

		doorGameObject.transform.position = lastPlatformPosition;
		doorGameObject.transform.SetParent(m_platformParent.transform);
	}

	// Spawn Flames from top
	void spawnFlames () {
		Instantiate(flames);
	}
}
