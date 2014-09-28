using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AdjustScale : MonoBehaviour 
{
    public float width, height;

    void Update()
    {
        transform.localScale = Vector3.one;

        float currentWidth = (renderer as SpriteRenderer).sprite.bounds.size.x;
        float currentHeight = (renderer as SpriteRenderer).sprite.bounds.size.y;

        double screenHeight = Camera.main.orthographicSize * 2.0;
        double screenWidth = screenHeight / Screen.height * Screen.width;

        float xScale = (float)(screenWidth / currentWidth / width);
        float yScale = (float)(screenHeight / currentHeight / height);

        Vector3 scale = transform.localScale;
        scale.x = xScale;
        scale.y = yScale;
        transform.localScale = scale;
    }
}
