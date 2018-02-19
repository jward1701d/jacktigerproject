using UnityEngine;
using System.Collections;

public class s_HS : MonoBehaviour {

	public GameObject[] _screenInfo;
	SaveSystemData data;
	static string _fileName = "highscore.dat";
	// Use this for initialization
	void Start () 
	{
		data = s_HighScoreSystem.LoadFromFile(_fileName,3);
		_screenInfo[0].GetComponent<TextMesh>().text = data.playerName[0];
		_screenInfo[1].GetComponent<TextMesh>().text = data.score[0].ToString();
		_screenInfo[2].GetComponent<TextMesh>().text = data.playerName[1];
		_screenInfo[3].GetComponent<TextMesh>().text = data.score[1].ToString();
		_screenInfo[4].GetComponent<TextMesh>().text = data.playerName[2];
		_screenInfo[5].GetComponent<TextMesh>().text = data.score[2].ToString();
	}
}
