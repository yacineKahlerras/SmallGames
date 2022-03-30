using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // the level prefab
    public List<GameObject> levelsObjects;
    List<Level> allLevels;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        allLevels = new List<Level>();

        SpawnLevelsAtStart();
    }

    // creates a new level each time player progresses
    public void SpawnLevel(Vector2 levelStartPosition = new Vector2())
    {
        // find the position of the color changer
        if (allLevels.Count > 0) levelStartPosition = allLevels[allLevels.Count - 1].colorChanger.position;

        // instatiate the gameObject and add its component to the list
        GameObject newLevelObject = Instantiate( levelsObjects[Random.Range(0, levelsObjects.Count)], 
                                                levelStartPosition,
                                                Quaternion.identity);
        if(newLevelObject.TryGetComponent(out Level level))
        {
            allLevels.Add(level);
            SortOutLevels();
        }
    }

    // this spawns levels at the start of the game
    public void SpawnLevelsAtStart()
    {
        SpawnLevel(player.transform.position);
        SpawnLevel();
    }

    // deletes all the levels that we passed
    public void SortOutLevels()
    {
        while(allLevels.Count > 3)
        {
            Destroy(allLevels[0].gameObject);
            allLevels.RemoveAt(0);
        }
    }
}