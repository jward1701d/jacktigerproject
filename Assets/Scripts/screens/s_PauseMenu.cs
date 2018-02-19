using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class s_PauseMenu : MonoBehaviour {

	
	#region Fields
	int _currentIndex = 0;
	int _minIndex;
	public int _maxIndex;
	public GameObject Player;
	public GameObject[] _menuTable;
	bool _whiteOut;
	#endregion
	
	#region Properties
	
	#endregion
	
	#region Functions
	void Update () 
	{
		MenuHighLighter();
		MenuInputController();
	}
	#region Menu Highlighter
	/// <summary>
	/// Color Highlighter code for the menu.
	/// Color = Yellow for selected color.
	/// Color = White for non-selected color.
	/// </summary>
	void MenuHighLighter()
	{
		// Resume Game Option
		if(_currentIndex == 0)
		{
			_menuTable[_currentIndex].GetComponent<Renderer>().material.color = Color.yellow;
			if(_whiteOut)
			{
				for(int i = (_currentIndex + 1); i < _maxIndex; i++)
				{
					_menuTable[i].GetComponent<Renderer>().material.color = Color.white;
					_whiteOut = false;
				}
			}
		}
		
		// Quit game option
		if(_currentIndex == 1)
		{
			_menuTable[_currentIndex].GetComponent<Renderer>().material.color = Color.yellow;
			if(_whiteOut)
			{
				for(int i = (_currentIndex + 1); i < _maxIndex; i++)
				{
					_menuTable[i].GetComponent<Renderer>().material.color = Color.white;
				}
				for(int j = (_currentIndex - 1); j < _currentIndex; j++)
				{
					_menuTable[j].GetComponent<Renderer>().material.color = Color.white;
				}
				_whiteOut = false;
			}
		}
	}
	#endregion
	
	#region Menu Input Controller
	/// <summary>
	/// Menu input controller.
	/// contols the availble key presses for the main menu.
	/// Avialble keypresses are : W,S,Down Arrow, Up Arrow, Enter.
	/// </summary>
	void MenuInputController()
	{
		if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
		{
			_currentIndex++;
			_whiteOut = true;
		}
		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
		{
			_currentIndex--;
			_whiteOut = true;
		}
		if(_currentIndex > _maxIndex)
			_currentIndex = _maxIndex;
		if(_currentIndex < 0)
			_currentIndex = 0;
		// Enter Key.
		if(Input.GetKeyUp(KeyCode.Return))
		{
			// Resume Game 
			if(_currentIndex == 0)
			{
				this.transform.rotation *= Quaternion.Euler(0,-90,0);
				Time.timeScale = 1.0f;
			}
			// Quit Game Score
			if(_currentIndex == 1)
			{
				Application.LoadLevel("menu");
			}
		}
	}
	#endregion
	
	#endregion
}
