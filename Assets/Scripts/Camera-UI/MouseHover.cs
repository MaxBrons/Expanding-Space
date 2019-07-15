using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    private Image HoverImg;

    private void Start()
    {
        HoverImg = GetComponent<Image>();
    }

    void OnMouseOver()
    {
        HoverImg.enabled = true;
    }

    void OnMouseExit()
    {
        HoverImg.enabled = false;
    }
}
