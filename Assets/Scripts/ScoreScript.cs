using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    
    [SerializeField] private GameObject blockPrefab;
    private int[,] maps = 
    { 
        {2, 2, 4, 4, 4, 1, 1, 1, 1, 3, 1},
        {2, 2, 4, 4, 4, 1, 1, 1, 1, 3, 1},
        {2, 2, 4, 4, 1, 4, 1, 1, 3, 3, 3},
        {2, 2, 2, 4, 1, 1, 1, 1, 3, 0, 3},
        {2, 2, 2, 4, 1, 1, 1, 1, 3, 0, 3},
        {2, 2, 2, 4, 1, 1, 1, 1, 3, 3, 3},
        {2, 2, 4, 4, 4, 1, 1, 1, 3, 3, 3},
        {2, 2, 4, 4, 4, 1, 1, 1, 3, 3, 3},
        {2, 2, 4, 4, 4, 1, 1, 1, 3, 3, 3},
        {2, 2, 4, 4, 4, 1, 1, 1, 1, 3, 1},
        {2, 2, 4, 4, 4, 1, 1, 1, 1, 3, 1},
    };
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        for (int x = 0; x < maps.GetLength(0); x++)
        {
            for (int z = 0; z < maps.GetLength(1); z++)
            {
                
                Debug.Log(maps[x, z]);
                
                GameObject block = Instantiate(blockPrefab, new Vector3(x, 0, z), Quaternion.identity);
                
                SetBlockColor(block, maps[x, z]);
            }
        }
    }

    void SetBlockColor(GameObject block, int tileType)
    {
        Color color = GetColorForTile(tileType);
        
        SpriteRenderer renderer = block.GetComponent<SpriteRenderer>();
        
        if (renderer != null)
        {
            renderer.color = color;
            Debug.Log($"Set color to {color} for tile {tileType}");
        }
        else
        {
            Debug.Log($"No SpriteRenderer found on block! Trying Renderer component.");
            
            Renderer r = block.GetComponent<Renderer>();

            if (r != null)
            {
                r.material.color = color;
                Debug.Log($"Set material color to {color} for tile {tileType}");
            }
            else
            {
                Debug.LogError("No Renderer found on block prefab!");
            }
        }
    }

    Color GetColorForTile(int tileType)
    {
        
        return tileType switch
        {
            0 => Color.black,
            1 => Color.darkGreen,
            2 => Color.blue,
            3 => Color.red,
            4 => Color.yellow,
            _ => Color.white
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
