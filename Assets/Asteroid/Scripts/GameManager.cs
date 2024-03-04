using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;//! singeltona dönüştürmek için
    public enum GameState { Menu, Game, LevelComplete, GameOver } //! oyun durumları

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
