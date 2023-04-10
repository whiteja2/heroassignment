using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float boundaryPercentage = 0.9f;
    private float boundaryWidth;
    private float boundaryHeight;
    private Vector3 topLeft;
    private Vector3 bottomRight;

    void Start()
    {
        // Get the world coordinates of the top-left and bottom-right corners of the screen
        topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        // Calculate the width and height of the screen in world units
        float width = bottomRight.x - topLeft.x;
        float height = topLeft.y - bottomRight.y;

        // Calculate the boundaries for spawning the enemies
        boundaryWidth = width * boundaryPercentage;
        boundaryHeight = height * boundaryPercentage;

        for (int i = 0; i < 10; i++)
        {
            spawnEnemy();
        }
    }
    
    public void spawnEnemy()
    {
        // Generate random x and y positions within the boundaries
            float x = Random.Range(topLeft.x + boundaryWidth, bottomRight.x - boundaryWidth);
            float y = Random.Range(bottomRight.y + boundaryHeight, topLeft.y - boundaryHeight);

            // Instantiate the enemy prefab at the random position
            Instantiate(enemyPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
