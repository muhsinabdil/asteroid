using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;//! singeltona dönüştürmek için
    public enum GameState { Menu, Game, LevelComplete, GameOver } //! oyun durumları
    private GameState gameState;//! oyun durumunu tutacak
    public static Action<GameState> onGameStateChanged;//! oyun durumunu değiştirecek Action
                                                       // Start is called before the first frame update



    private void Awake()
    {
        if (instance != null)
        {
            //! başka bir oyun yöneticisi var ise
            Destroy(gameObject);//! bu oyun yöneticisini yok et

        }
        else
        {
            instance = this;
        }
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState; //! playe basınca game durumunu çağıracak

        onGameStateChanged?.Invoke(gameState);//! oyun durumunu değiştirecek

    }
    public bool IsGameState()
    {
        return gameState == GameState.Game;//! oyun durumunu true veya false döndürür
    }
    void Start()
    {
        SetGameState(GameState.Game);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
