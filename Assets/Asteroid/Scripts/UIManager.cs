using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        gamePanel.SetActive(true);
        finishPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);//! leveli yazdırıyoruz

    }

    // Update is called once per frame
    void Update()
    {

    }
}
