using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    //! bu scriptte yapmaya çalıştığım yolları oluşturmak x ve y değerleri önceden belirlenir
    //! parçaların uzunluğunu dönüyoruz
    //! parçalar için gizmos ile çizim yapıyoruz bu sayede sahnede daha rahat görebiliyoruz


    [Header("Settings")]
    [SerializeField] private Vector2 size;//! boyutu
                                          // Start is called before the first frame update

    public float GetLength()
    {
        return size.y;//! uzunluğu döndür
    }

    public void OnDrawGizmos()
    {
        //! 
        Gizmos.color = Color.red;//! renk at

        Gizmos.DrawWireCube(transform.position, size);//! tel Küp çiz 
    }

}
