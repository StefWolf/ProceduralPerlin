using UnityEngine;

public class PixelGeneration : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    public float offsetX = 100f;
    public float offsetY = 100f;

    [Range(0,1)]
    public float f1 = 0.3f;
    [Range(0,1)]
    public float f2 = 0.5f;
    [Range(0,1)]
    public float f3 = 0.7f;

    void Start()
    {
        offsetX = Random.Range(0, 99999f);
        offsetY = Random.Range(0, 99999f);
    }
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = calculateColor(x,y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }
    Color calculateColor(int x,int y)
    {
        float xCoord = (float)x / width * scale * offsetX;
        float yCoord = (float)y / height * scale * offsetY;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        
        // if(sample < 0.1f ) {
        //     return new Color(0.1f, 0.2f, 0.5f);
        // } else if (sample >= 0.1f && sample < 0.2f){
        //     return new Color(0.5f, 0.9f, 0.9f);
        // } else if (sample >= 0.2f && sample < 0.3f){
        //     return new Color(0.1f, 0.4f, 0.9f);
        // }

        //Debug.Log(sample);

        Color cor = new Color();

        if(sample < f1){
            cor = new Color(0.8f,0.8f,0.8f);
        }

        if(sample >= f1 && sample < f2){
            cor = new Color(0.6f,0.6f,0.6f);
        }

        if(sample >= f2 && sample < f3){
            cor = new Color(0.4f, 0.4f, 0.4f);
        }

        if(sample >= f3){
            cor = new Color(0.2f,0.2f,0.2f);
        }

        return cor;
    }
}