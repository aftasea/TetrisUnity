using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
	[Tooltip("Vertical offset from grid in units")]
	[SerializeField]
	private int verticalOffset;

	private Playfield playfield;
	private Camera cam;

	private const float halfUnit = 0.5f;

	private void Awake()
	{
		cam = GetComponent<Camera>();
		playfield = FindObjectOfType<Playfield>();
		playfield.OnGridSizeChanged += UpdateCamera;
		UpdateCamera();
	}

	private void UpdateCamera()
	{
		cam.orthographicSize = (playfield.Rows + verticalOffset) / 2;
		Vector3 camPos = cam.transform.position;
		float posY = halfUnit - (playfield.Rows / 2);
		cam.transform.position = new Vector3(camPos.x, posY, camPos.z);
	}
}
