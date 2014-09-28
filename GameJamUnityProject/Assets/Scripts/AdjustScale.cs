using UnityEngine;
using System.Collections;

public class AdjustScale : MonoBehaviour 
{
    public float width, height;

    void Start()
    {
        float currentWidth = (renderer as SpriteRenderer).sprite.bounds.size.x * transform.localScale.x;
        float currentHeight = (renderer as SpriteRenderer).sprite.bounds.size.y * transform.localScale.y;

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float screenWidth = topRight.x - bottomLeft.x;
        float screenHeight = topRight.y - bottomLeft.y;

        float xScale = currentWidth / screenWidth * width;
        float yScale = currentHeight / screenHeight * height;

        Vector3 scale = transform.localScale;
        scale.x /= xScale;
        scale.y /= yScale;
        transform.localScale = scale;
    }
}
