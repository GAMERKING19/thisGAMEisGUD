using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public GameObject TileDirt;
    public GameObject TileGrass;
    public GameObject TileStone;

    public int width;
    public int heightAddition;

    public float heightmultiplier;
    public float smoothness;

    float seed;

    void Start()
    {
        Generate();
        seed = Random.Range(-10000f, 10000f);
    }

    public void Generate()
    {
        for (int i = 0; i < width; i++)
        {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, i / smoothness) * heightmultiplier) + heightAddition;
            for (int j = 0; j < h; j++)
            {
                GameObject selectedTile;
                if (j < h - 4)
                {
                    selectedTile = TileStone;
                }
                else if (j < h - 1)
                {
                    selectedTile = TileDirt;
                }
                else
                {
                    selectedTile = TileGrass;
                }
                Instantiate(selectedTile, new Vector3(i, j), Quaternion.identity);
            }
        }

    }
}   