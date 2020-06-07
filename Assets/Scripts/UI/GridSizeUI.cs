using UnityEngine;
using UnityEngine.UI;

public class GridSizeUI : MonoBehaviour
{
	[SerializeField]
	public InputField rowsField;

	private Button setButton;
	private Playfield playfield;

	private void Awake()
	{
		playfield = FindObjectOfType<Playfield>();
		setButton = GetComponentInChildren<Button>();
		setButton.onClick.AddListener(ProcessInput);
		rowsField.text = playfield.Rows.ToString();
	}

	private void ProcessInput()
	{
		bool isDataValid = true;
		int rows = int.Parse(rowsField.text);
		if (rows < 4)
		{
			rowsField.text = playfield.Rows.ToString();
			isDataValid = false;
		}

		if (isDataValid)
			playfield.SetGridSize(rows);
	}
}
