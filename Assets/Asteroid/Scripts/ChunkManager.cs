using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

        public static ChunkManager instance;//! chunkmanagerın örneğini alıyoruz tek olmalı

    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
