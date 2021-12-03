using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 positionOffsets;
    public LevelManager lm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Target").Length == 0 && !lm.gameOver && lm.startGame)
        {
            float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + positionOffsets.y,
                    Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - positionOffsets.y);
            float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + positionOffsets.x,
                    Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - positionOffsets.x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            lm.IncrementTotalTargets();
        }

    }
}
