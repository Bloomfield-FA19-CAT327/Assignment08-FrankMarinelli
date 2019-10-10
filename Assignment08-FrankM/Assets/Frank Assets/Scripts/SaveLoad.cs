using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {
	public static List<GameData> savedGames = new List<GameData>();

	//it's static so we can call it from anywhere
	public static void Save() {
		SaveLoad.savedGames.Add(GameData.current);
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd");
		bf.Serialize(file, SaveLoad.savedGames);
		file.Close();
	}

	public static void Load() {
		if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd")) {
			Debug.Log("Loading:" + Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd", FileMode.Open);
			SaveLoad.savedGames = (List<GameData>) bf.Deserialize(file);
			file.Close();
		}
	}
}