using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{


    //! bu scriptte yapmaya çalıştığım asteroidleri yönetmek
    //! asteroidlerin hareketlerini sağlamak
    //! asteroidlerin çarpışmalarını algılamak
    //! asteroidlerin yok olmasını sağlamak
    //! asteroidlerin sağlığını belirlemek
    // Start is called before the first frame update

    public float health = 0;

    void Start()
    {

        health = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {


        if (GameManager.instance.IsGameState())
        {
            transform.position += Vector3.down * Time.deltaTime * 1;

            DetectColliders();//! Çarpışmaları algılayacak bir fonksiyon yazıyoruz
        }



    }

    private void DetectColliders()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, transform.localScale.x);//! büyüklük kadar bir alan oluşturduk ve bu alan içindeki colliderları algılayacak
        foreach (var hitCollider in hitColliders)
        {


            if (hitCollider.CompareTag("bullet"))
            {

                health -= 1;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
            if (hitCollider.CompareTag("player"))
            {


                Destroy(gameObject);

            }


            if (hitCollider.CompareTag("deathline"))
            {

                Destroy(gameObject);
            }





        }
    }


}
