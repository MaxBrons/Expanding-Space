using UnityEngine;

public class backgroundScroller : MonoBehaviour
{
    [SerializeField] private float parralax = 2f;

    void Update()
    {
        //Gets the meshrenderer on the Quad
        MeshRenderer mr = GetComponent<MeshRenderer>();

        //Gets the material that's on the Quad
        Material mat = mr.material;

        //The offset from the material is used to create the paralex effect
        Vector2 offset = mat.mainTextureOffset;

        //The offset of the materials X and Y depends on the Quads movement
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        //Sets the texure offset to the variable offset its values
        mat.mainTextureOffset = offset;
    }
}


