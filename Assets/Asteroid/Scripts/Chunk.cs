using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
