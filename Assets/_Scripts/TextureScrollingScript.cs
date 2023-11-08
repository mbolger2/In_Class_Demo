using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrollingScript : MonoBehaviour
{
    // A reference to the mesh for this object, where the material lives
    public MeshRenderer textureMesh;

    // The rate at which the tiling will change every second
    public Vector2 tilingSpeed;

    // A private reference to the material we're offsetting, so 
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // We cache the material of the mesh for quick access later
        mat = textureMesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the main texture and normal map offset to be its current value
        //mat.mainTextureOffset += tilingSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex",
            mat.GetTextureOffset("_MainTex") + tilingSpeed * Time.deltaTime);

        mat.SetTextureOffset("_DetailAlbedoMap",
            mat.GetTextureOffset("_DetailAlbedoMap") + tilingSpeed * Time.deltaTime);
    }
}
