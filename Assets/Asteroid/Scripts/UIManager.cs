using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    //! bu scriptte yapmaya çalıştığım UI componentlerini yönetmek
    //! oyun durumuna göre panelleri aktif pasif yapmak
    //! Player can barını güncellemek
    //! leveli yazdırmak

    [Header("Elements")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {

        gamePanel.SetActive(true);
        finishPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);//! leveli yazdırıyoruz


        GameManager.onGameStateChanged += GameStateChangedCallBack;//! oyun durumunu dinliyoruz
    }
    void Update()
    {
        UpdateProgressBar();

    }
    private void OnDestroy()
    {

        //! start içinde oyun durumuna abonelik yapmıştık 
        //! nesne yok olduğunda bu abonelikten çıkıyoruz

        GameManager.onGameStateChanged -= GameStateChangedCallBack;//! dinlemeyi bıraktık
    }

    private void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())//! oyun durumunda değilse 
            return;//! false ise boş döner

        float health = PlayerManager.instance.GetHealth();
        healthBar.value = health;


    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)//! oyun durumunu alan methodu yarattık
    {
        //! oyun durumunu kalabalık yöneticisinden değiştiriyoruz
        //
        switch (gameState) //! oyun durumuna göre yapılacak işlemler
        {
            case GameManager.GameState.Menu:
                // ShowMenu();
                break;
            case GameManager.GameState.Game:
                //  ShowGame();
                break;
            case GameManager.GameState.LevelComplete:

                ShowLevelComplete();//! finish panel aktif 
                break;
            case GameManager.GameState.GameOver:
                ShowGameOver();//! game over panel aktif 
                break;
            default:
                break;
        }


    }
    public void ShowLevelComplete()
    {

        //! oyun manager state yönetimine abone olmak gerek bunu start ta yaptık

        gamePanel.SetActive(false);//! Oyun panelini pasif yapıyoruz
        finishPanel.SetActive(true);//! level complete paneli aktif yapıyoruz
    }
    public void ShowGameOver()
    {

        //! oyun manager state yönetimine abone olmak gerek bunu start ta yaptık

        gamePanel.SetActive(false);//! Oyun panelini pasif yapıyoruz
        gameOverPanel.SetActive(true);//! Game over paneli aktif yapıyoruz
    }

    // Update is called once per frame

}
