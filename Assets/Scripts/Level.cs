using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Level : MonoBehaviour
{

    [SerializeField] private GameObject _note;

    string path = "Assets/Maps/";

    public static Dictionary<int, Vector3> Directions = new Dictionary<int, Vector3>
    {
        {0, new Vector3(-12, 3, 0)},
        {1, new Vector3(-12, 0, 0)},
        {2, new Vector3(-12, -3, 0)},
        {3, new Vector3(12, 3, 0)},
        {4, new Vector3(12, 0, 0)},
        {5, new Vector3(12, -3, 0)}
    };

    bool mapOngoing = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayMap", "map1");
    }

    IEnumerator PlayMap(string mapName)
    {
        yield return new WaitForSeconds(1f);

        mapOngoing = true;
        Music musicPlayer = GetComponent<Music>();

        string mapText = File.ReadAllText(path + mapName + ".json");
        Map[] map = MapInfo.FromJson<Map>(mapText);

        musicPlayer.PlayMusic();
        yield return new WaitForSeconds(0.32f);

        int nextNote = 0;

        while (mapOngoing)
        {
            if (musicPlayer.GetTime() >= map[nextNote].time - 1.4f)
            {
                Instantiate(_note, Directions[map[nextNote].note], Quaternion.identity);
                nextNote++;
            }
            yield return null;
        }
    }
}

[System.Serializable]
public class Map {
    public int id;
    public int note;
    public float time;
}


