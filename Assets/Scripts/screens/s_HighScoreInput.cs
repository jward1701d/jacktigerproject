using UnityEngine;
using System.Collections;
using System.Text;

public class s_HighScoreInput : MonoBehaviour {

	#region Fields
	static string _playerName = "";
	char[] _alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
	int _currentIndex = 0;
	int _maxIndex;
	int _namePos = 0;
	public int _maxChars;
	public GameObject _playerScore;
	static string _fileName = "temp.dat";
	static string _saveGameData = "highscore.dat";
	string _score;
	SaveSystemData data;
	float timerDelay = 15.0f;
	#endregion
	
	#region Properties
	public static string PlayerName
	{
		get { return _playerName;}
	}
	#endregion
	
	#region Functions
	void Start () 
	{
		_maxIndex = _alphabet.Length;
		data = s_HighScoreSystem.LoadFromFile(_saveGameData,3);
		_score = s_HighScoreSystem.ReadFromFile(_fileName);
		s_HighScoreSystem.ScoreCheck(data, int.Parse(_score));
		_playerName ="";
	}
	
	void Update () 
	{
		if(s_HighScoreSystem.isHighScore)
			HighScoreInputs();
		else
		{
			//if(Input.GetKeyUp(KeyCode.Return))
			//{
			//	Application.LoadLevel("menu");
			//}
			StartCoroutine(DelayTimer());
		}
	}
	
	#region High Score Input
	/// <summary>
	/// Handles the player input and display information for any screen thats using the High Score System.
	/// </summary>
	void HighScoreInputs()
	{
		if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
		{
			_currentIndex++;
		}
		if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
		{
			_currentIndex--;
		}
		if(Input.GetKeyUp(KeyCode.Return))
		{
			_playerName = _playerName + _alphabet[_currentIndex].ToString();
			_namePos++;
		}
		if(_currentIndex >= _maxIndex)
			_currentIndex = _maxIndex-1;
		if(_currentIndex < 0)
			_currentIndex = 0;
		if(_namePos == 0)
			GetComponent<TextMesh>().text = _alphabet[_currentIndex].ToString();
		if(_namePos >= 1 && _namePos < _maxChars)
		{
			GetComponent<TextMesh>().text = _playerName + _alphabet[_currentIndex].ToString();
		}
		_playerScore.GetComponent<TextMesh>().text = _score;
		if((Input.GetKeyUp(KeyCode.Return)) && _namePos == _maxChars)
		{
			s_HighScoreSystem.CheckScores(data,int.Parse(_score),_saveGameData);
			Application.LoadLevel("menu");
		}
	}
	IEnumerator DelayTimer()
	{
		yield return new WaitForSeconds (timerDelay);
		Application.LoadLevel("menu");
	}
	#endregion
	
	#endregion
}
