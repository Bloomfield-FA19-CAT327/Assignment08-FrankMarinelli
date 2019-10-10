using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
	public static GameData current;
	public CharacterData gunner;
	public CharacterData juggernaut;
	public CharacterData spy;
	public CharacterData sniper;

	public GameData() {
		gunner = new CharacterData();
		juggernaut = new CharacterData();
		spy = new CharacterData();
		sniper = new CharacterData();
	}
}
