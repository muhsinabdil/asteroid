using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    [Header("Events")]
    ///  bir olay yarattık kapılara çarptığımızda ses çalacak
    public static Action onAsteroidsHit;
    public static Action onEnemiesHit;
    public static Action onCoinsHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsGameState()) //! oyun modundaysa çarpışmalar algılanacak. 
            DetectColliders();//! Çarpışmaları algılayacak bir fonksiyon yazıyoruz
    }

    private void DetectColliders()
    {
       
    }
}
