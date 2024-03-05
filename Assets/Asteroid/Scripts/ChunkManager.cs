using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

    public static ChunkManager instance;//! chunkmanagerın örneğini alıyoruz tek olmalı

    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;

    private GameObject finishLine;//! bitişin konumunu almak için yardımcı olacak bu sayede slidera etki edeceğiz



    public void Awake()
    {//! instance varsa onu yok ediyoruz
     //! çünkü parça yöneticisi tek olmalı

        if (instance != null)
        {
            Destroy(gameObject);//! parça yöneticisini yok ediyoruz
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();

        finishLine = GameObject.FindWithTag("Finish");//! bitişi alıyoruz
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateLevel()
    {
        //! seviyeye göre uygulayacağız
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;//! seviye sayısını alıyoruz
        LevelSO level = levels[currentLevel];


        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
    {

        Vector2 chunkPosition = Vector2.zero;

        for (int i = 0; i < levelChunks.Length; i++)//! levelchunks içindeki parçalar kadar döner
        {


            Chunk chunkToCreate = levelChunks[i];//! parçaları sırayla alıyoruz 

            if (i > 0)
            {


                chunkPosition.y += chunkToCreate.GetLength() / 2;//!  parçanın  uzunluğunun yarısını alıyoruz ve y değerine ekliyoruz

            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            //!parçalar farklı olduğu için uzunlukların yarısı kadar ileriye gidiyoruz
            chunkPosition.y += chunkInstance.GetLength() / 2;


        }

    }


    public float GetFinishY()
    {
        return finishLine.transform.position.y;
    }


    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);//! default değeri 0 yaptık
    }
}
