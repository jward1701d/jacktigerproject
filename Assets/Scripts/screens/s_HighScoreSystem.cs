using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

#region Save System Data Struct
/// <summary>
/// Save system data.
/// Used to store arrays of information used in the game for high score system.
/// </summary>
public struct SaveSystemData
{
	public string[] playerName;
	public int[] score;
	public int Count;
	
	public SaveSystemData(int count)
	{
		playerName = new string[count];
		score = new int[count];
		Count = count;
	}
}
#endregion

#region s_HighScoreSystem Class
/// <summary>
/// High Score System.
/// contains all the methods for reading and writing to a file for the game.
/// </summary>
public class s_HighScoreSystem : MonoBehaviour 
{
	#region Fields
	static string _path;
	static string _saveFileName = "temp.dat";
	static bool _isHighScore= false;
	//public string _fileName;
	#endregion
	
	#region Properties
	public static bool isHighScore
	{
		get {return _isHighScore;}
	}
	#endregion
	
	#region Functions
	void Update()
	{
		if(this.gameObject.name == "p_Player")
		{
			if(s_Player.Lives == 0)
			{
				SaveToFile(s_Player.Score);
			}
		}
	}
	
	#region Check Score 
	// Checks to see if the players score is high enough to be entered in the high score system.
	public static void ScoreCheck(SaveSystemData data, int score)
	{
		for(int i = 0; i < data.Count; i++)
		{
			if(score > data.score[i])
			{
				_isHighScore = true;
				break;
			}
		}
	}
	// Sorts the high score list and places the new score in the list.
	public static void CheckScores(SaveSystemData data, int score, string _file)
	{
		int scoreIndex = -1;
		
		for(int i = 0; i < data.Count; i++)
		{
			if(score > data.score[i])
			{
				scoreIndex = i;
				break;
			}
		}
		if(scoreIndex > -1)
		{
			for(int i = data.Count - 1; i > scoreIndex; i--)
			{
				data.playerName[i] = data.playerName[i-1];
				data.score[i] = data.score[i-1];
			}
			data.playerName[scoreIndex] = s_HighScoreInput.PlayerName;
			data.score[scoreIndex] = score;
		}
		SaveToFile(data, _file);
	}
	#endregion
	
	#region Save To File
	// Used for transitioning between scenes.
	public static void SaveToFile(int data)
	{
		_path = Application.dataPath + "/"+_saveFileName;
		using (FileStream fs = File.Create(_path))
		{
			using(StreamWriter writer = new StreamWriter(fs))
			{
				writer.WriteLine(data.ToString());
			}
		}
	}
	// Used to store the high scores to a file.
	public static void SaveToFile(SaveSystemData data, string _file)
	{
		_path = Application.dataPath + "/"+_file;
		using(StreamWriter writer = new StreamWriter(_path))
		{
			for(int i = 0; i < data.Count; i++)
			{
				writer.WriteLine(data.playerName[i]);
				writer.WriteLine(data.score[i].ToString());
			}
		}
	}
	#endregion
	
	#region Read and load file
	// used as a transiont read from scene to scene.
	public static string ReadFromFile(string savedFile)
	{
		string temp;
		_path = Application.dataPath + "/"+ savedFile;
		using (StreamReader sr = new StreamReader(_path))
		{
			temp = sr.ReadToEnd();
		}
		return temp;
	}
	// Loads the data for the high scores from a file.
	public static SaveSystemData LoadFromFile(string savedFile, int size)
	{
		_path = Application.dataPath + "/"+ savedFile;
		SaveSystemData data = new SaveSystemData(size);
		
		if(File.Exists(_path))
		{	
			using(StreamReader sr = new StreamReader(_path))
			{
				int i = 0;
				while(!sr.EndOfStream)
				{
					data.playerName[i] = sr.ReadLine();
					data.score[i] = int.Parse(sr.ReadLine());
					i++;
				}
			}
		}
		else
		{
			data.playerName[0] = "James";
			data.score[0] = 500;
			data.playerName[1] = "David";
			data.score[1] = 300;
			data.playerName[2] = "Jacob";
			data.score[2] = 100;
				
		}
		return data;
	}
	#endregion
	#endregion
}
#endregion