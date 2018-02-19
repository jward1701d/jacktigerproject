using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class s_MenuSystem : MonoBehaviour {

	
	#region Fields
	int _currentIndex = 0;
	int _minIndex;
	public int _maxIndex;
	public GameObject[] _menuTable;
	public string _loadNextLevel;
	bool _whiteOut;
	bool _isHighScore;
	bool _isCredits;
	bool _isQuit;
	Quaternion tempRot;
	
	#endregion
	
	#region Properties
	
	#endregion
	
	#region Functions
	void Start()
	{
		_currentIndex = 0;
		_isCredits = false;
		_isHighScore = false;
		_isQuit = false;
		tempRot = this.transform.rotation;
	}
	
	void Update () 
	{
		//Time.timeScale = 0.0f;
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
		// Credits
		if(_isCredits)
		{
			_currentIndex = 4;
			_whiteOut = false;
		}
		
		// High Score
		if(_isHighScore)
		{
			_currentIndex = 5;
			_whiteOut = false;
		}
			
		// Play Game Option
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
		
		// High Score option
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
		
		// Credits option
		if(_currentIndex == 2)
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
		
		// Quit option
		if(_currentIndex == 3)
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
					_whiteOut = false;
				}
			}
		}
		
		// Credits back button option.
		if(_currentIndex == 4)
		{
			_menuTable[_currentIndex].GetComponent<Renderer>().material.color = Color.yellow;
			_menuTable[2].GetComponent<Renderer>().material.color = Color.white;
		}
		
		// High Score back button option.
		if(_currentIndex == 5)
		{
			_menuTable[_currentIndex].GetComponent<Renderer>().material.color = Color.yellow;
			_menuTable[1].GetComponent<Renderer>().material.color = Color.white;
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
			//StartCoroutine(EnterCheck());
			_currentIndex++;
			_whiteOut = true;
		}
		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
		{
			//StartCoroutine(EnterCheck());
			_currentIndex--;
			_whiteOut = true;
		}
		/*
		if(_currentIndex > 3 && (!_isCredits || !_isHighScore))//_maxIndex && (!_isCredits || !_isHighScore))
		{
			if(!_isCredits || !_isHighScore)
			{
				Debug.Log("Quit is the max");
				_currentIndex = 3;
			}
			else
				_currentIndex = _maxIndex;
		}
		if(_currentIndex > 3 && (_isCredits || _isHighScore))
		{
			_currentIndex = _maxIndex;
		}
		*/
		if(_currentIndex > 3 && (!_isCredits || !_isHighScore))
		{
			if(_isCredits)
				_currentIndex = 4;
			else if(_isHighScore)
				_currentIndex = 5;
			else
				_currentIndex = 3;
		}
		if(_currentIndex < 0)
			_currentIndex = 0;
		// Enter Key.
		if(Input.GetKeyUp(KeyCode.Return))
		{
			//StartCoroutine(EnterCheck());
			// Play Game 
			if(_currentIndex == 0)
			{
				s_Player.Score = 0;
				s_Player.Lives = 3;
				s_Player.population = 100;
				s_Player.weaponType = "mainCannon";
				s_Player.playerSpeed = 5;
				s_Player.myDamage = 10.0f;
				s_level.enemiesSpawning = true;
				s_level.gameTime = 204.0f;
				s_Player.myHealth = 10;
				this.transform.rotation = tempRot;
				GetComponent<AudioSource>().Stop();
				Application.LoadLevel(_loadNextLevel);
			}
			// High Score
			if(_currentIndex == 1)
			{
				this.transform.rotation *= Quaternion.Euler(0,-90,0);
				_isHighScore = true;
			}
			//Credits
			if(_currentIndex == 2)
			{
				this.transform.rotation *= Quaternion.Euler(0,90,0);
				_isCredits = true;
			}
			// Quit
			if(_currentIndex == 3)
			{
				_currentIndex = 0;
				_menuTable[3].GetComponent<Renderer>().material.color = Color.white;
				this.transform.rotation = tempRot;
				GetComponent<AudioSource>().Stop();
				Application.Quit();
			}
			//Credits Screen
			if(_currentIndex == 4)
			{
				_currentIndex = 0;
				this.transform.rotation = tempRot;//*= Quaternion.Euler(0,-90,0);
				_isCredits = false;
			}
			// High Score screen.
			if(_currentIndex == 5)
			{
				_currentIndex = 0;
				this.transform.rotation = tempRot;//*= Quaternion.Euler(0,90,0);
				_isHighScore = false;
			}
		}
	}
	
	IEnumerator EnterCheck()
	{
		yield return new WaitForSeconds(0.10f);
	}
	#endregion
	
	#endregion
}
