using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [Header("Settings")]
    [SerializeField] private float moveSpeed;//! hareket hızı
    [SerializeField] private float roadWidth;//! yol genişliği
    [SerializeField] private float slideSpeed;//! sağa sola kaydırma hızı

    private Vector3 clickedScreenPosition; //! ekran konumu
    private Vector3 clickedPlayerPosition; //! player konumu
    private bool canMove; //! hareket edebilir mi
                          // Start is called before the first frame update
    private void Awake()
    {


        if (instance != null)
        {
            Destroy(gameObject); //! birden fazla  player manager varsa yok ediyoruz
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallBack;//! etkinlik aboneliğini yapıyoruz
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)//! hareket edebilir true olunca hareket edebilecek
        {

            ManageControl();
        }


    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        //! oyun durumunu alıyoruz

        switch (gameState)
        {
            case GameManager.GameState.Menu:
                StopMoving();
                break;
            case GameManager.GameState.Game:
                StartMoving();
                break;
            case GameManager.GameState.LevelComplete:
                StopMoving();
                break;
            case GameManager.GameState.GameOver:
                StopMoving();
                break;
            default:
                break;
        }

    }
    private void StartMoving()
    {

        canMove = true;//! hareket edebilir

    }

    private void StopMoving()
    {

        canMove = false;//! hareket edemez

    }




    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        { //! dokunmaları alıyoruz

            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {

            //! tıklama konumu ile ekrandaki mevcut konum farkını hesaplıyoruz
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;//! ekranın genişliğine bölüyoruz
            xScreenDifference *= slideSpeed;//! sağa sola kaydırma hızıyla çarpıyoruz


            //! sağ sol hareketi için x değerini değiştirmeliyiz.
            Vector2 position = transform.position; //!  1 => position değişkeni oluşturuyoruz player positionunu atıyoruz
            position.x = clickedPlayerPosition.x + xScreenDifference;//! 2 =>sadece x değeri ile oynuyoruz
            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + 2, roadWidth / 2 - 2);//! 3=> x değerini min ve max olarak sınırlıyoruz sol sınıra
            transform.position = position; //! 4=> oluşturulan positionu playera atıyoruz

        }


    }
}
