using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{

    [Header("Elements")]

    [SerializeField] private Transform spaceQuad;
    // Start is called before the first frame update
    private MeshRenderer spaceQuadRenderer;
    private Material spaceMaterial;
    void Start()
    {
        spaceQuadRenderer = spaceQuad.GetComponent<MeshRenderer>();
        spaceMaterial = spaceQuadRenderer.material;
        spaceMaterial.SetTextureOffset("_MainTex", new Vector2(0, 0));

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 offsetM = spaceMaterial.mainTextureOffset;
        offsetM.y += Time.deltaTime / 100;
        spaceMaterial.SetTextureOffset("_MainTex", offsetM);

    }
}
