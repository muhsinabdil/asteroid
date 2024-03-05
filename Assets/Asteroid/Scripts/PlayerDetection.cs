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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f); //! 0.5f lik bir alan oluşturduk ve bu alan içindeki colliderları algılayacak
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("asteroid")) //! eğer asteroidse
            {
                onAsteroidsHit?.Invoke(); //! asteroid çarptığında olay tetiklenecek
                Destroy(hitCollider.gameObject); //! asteroidi yok edecek
            }
            if (hitCollider.CompareTag("enemy")) //! eğer düşman ise
            {
                onEnemiesHit?.Invoke();
            }
        }
    }
}
