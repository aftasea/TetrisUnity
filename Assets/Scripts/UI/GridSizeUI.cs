using UnityEngine;
using UnityEngine.UI;

public class GridSizeUI : MonoBehaviour
{
	[SerializeField]
	public InputField rowsField;
	[SerializeField]
	public InputField columnsField;

	private Button setButton;
	private Playfield playfield;

	private const int minRows = 4;
	private const int minColumns = 4;

	private void Awake()
	{
		playfield = FindObjectOfType<Playfield>();
		setButton = GetComponentInChildren<Button>();
		setButton.onClick.AddListener(ProcessInput);
		rowsField.text = playfield.Rows.ToString();
		columnsField.text = playfield.Columns.ToString();
	}

	private void ProcessInput()
	{
		bool isDataValid = true;
		int rows = int.Parse(rowsField.text);
		if (rows < minRows)
		{
			rowsField.text = playfield.Rows.ToString();
			isDataValid = false;
		}

		int cols = int.Parse(columnsField.text);
		if (cols < minColumns)
		{
			columnsField.text = playfield.Columns.ToString();
			isDataValid = false;
		}

		if (isDataValid)
			playfield.SetGridSize(rows, cols);
	}
}
