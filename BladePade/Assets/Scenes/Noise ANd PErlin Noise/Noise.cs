using UnityEngine;

public class Noise : MonoBehaviour {
    //Size of the texture
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;



    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>(); //Getting renfere component to control the texture;
        renderer.material.mainTexture = GenerateTexture();
    }
    Texture2D GenerateTexture(){
        Texture2D texture = new Texture2D(width, height);
        //Generate noise;
        for (int x = 0; x < width; x++){
            for (int y = 0; x < height; y++ ){
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }
    Color CalculateColor(int x, int y){
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
         
    }

    int GenerateDigit()
    {

        return Random.Range(0, 1);

    }


}
