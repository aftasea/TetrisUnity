using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
	[Tooltip("Vertical offset from grid in units")]
	[SerializeField]
	private int verticalOffset = 2;

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
		UpdateOrtographicSize();
		UpdatePosition();
	}

	private void UpdateOrtographicSize()
	{
		float gridAspectRatio = (float)playfield.Columns / playfield.Rows;

		if (gridAspectRatio <= cam.aspect)
		{
			cam.orthographicSize = (playfield.Rows + verticalOffset) / 2f;
		}
		else
		{
			float offset = verticalOffset / gridAspectRatio;
			float ratio = cam.aspect / gridAspectRatio;
			cam.orthographicSize = ((playfield.Rows + offset) / ratio) / 2f;
		}
	}

	private void UpdatePosition()
	{
		float posX = (playfield.Columns / 2f) - halfUnit;
		float posY = halfUnit - (playfield.Rows / 2f);
		cam.transform.position = new Vector3(posX, posY, cam.transform.position.z);
	}
}
