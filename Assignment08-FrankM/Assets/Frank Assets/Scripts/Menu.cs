using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public GameObject canvasMenu;
	public GameObject canvasNewGame;
	public GameObject canvasLoadGame;

	public InputField textGunner;
	public InputField textJuggernaut;
	public InputField textSpy;
	public InputField textSniper;

	public GameObject buttonHolder;
	public GameObject buttonPrefab;

	void Awake() { ShowMainMenu(); }

	public void ShowMainMenu() {
		canvasMenu.SetActive(true);
		canvasLoadGame.SetActive(false);
		canvasNewGame.SetActive(false);
	}

	public void ShowLoadGame() {
		canvasMenu.SetActive(false);
		canvasLoadGame.SetActive(false);
		canvasNewGame.SetActive(false);
	}

	public void ShowNewGame() {
		canvasMenu.SetActive(false);
		canvasLoadGame.SetActive(false);
		canvasNewGame.SetActive(true);
		GameData.current = new GameData();
		textGunner.text = GameData.current.gunner.name;
		textJuggernaut.text = GameData.current.juggernaut.name;
		textSpy.text = GameData.current.spy.name;
		textSniper.text = GameData.current.sniper.name;
	}

	public void SaveAndStartGame() {
		GameData.current.gunner.name = textGunner.text;
		GameData.current.juggernaut.name = textJuggernaut.text;
		GameData.current.spy.name = textSpy.text;
		GameData.current.sniper.name = textSniper.text;
		SaveLoad.Save();
		SceneManager.LoadScene(1);
	}

	public void GenerateButtonsForGame() {
		SaveLoad.Load();
		foreach(GameObject oldButtons in GameObject.FindGameObjectsWithTag("LoadGameButton")) {
			Destroy(oldButtons);
		}
		foreach(GameData game in SaveLoad.savedGames) {
			Debug.Log("Will add button: " + game.gunner.name + game.juggernaut.name + game.spy.name + game.sniper.name);
			GameObject gameButtonObject = Instantiate(buttonPrefab, canvasLoadGame.transform);
			if (gameButtonObject) {
				gameButtonObject.GetComponentInChildren<Text>().text = game.gunner.name + " - " + game.juggernaut.name + " - " + game.spy.name + " - " + game.sniper.name + " - ";
				gameButtonObject.GetComponentInChildren<Button>().onClick.AddListener(delegate { GameLoadClicked(game); });
			
			}
		}
	}
	
	public void GameLoadClicked(GameData game) {
		GameData.current = game;
		SceneManager.LoadScene(1);
	}
}
