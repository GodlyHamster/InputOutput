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
        mapOngoing = true;

        string mapText = File.ReadAllText(path + mapName + ".json");
        Map[] map = MapInfo.FromJson<Map>(mapText);

        GetComponent<Music>().PlayMusic();
        yield return new WaitForSeconds(0.3f);

        while (mapOngoing)
        {
            for (int i = 0; i < map.Length; i++)
            {
                float nextStamp = 0;

                Instantiate(_note, Directions[map[i].note], Quaternion.identity);

                nextStamp = map[i + 1].time;
                Debug.Log(map[i].id + ": " + (nextStamp - map[i].time));
                yield return new WaitForSeconds(nextStamp - map[i].time);
            }
            mapOngoing = false;
        }
    }
}

[System.Serializable]
public class Map {
    public int id;
    public int note;
    public float time;
}


