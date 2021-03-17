using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Level : MonoBehaviour
{

    [SerializeField] private GameObject _note;

    enum Direction { 
        TopLeft,
        MidLeft,
        BotLeft,
        TopRight,
        MidRight,
        BotRight
    }

    string path = "Assets/Maps/";

    bool mapOngoing;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("PlayMap", "map1");
        Debug.Log(MapInfo.GetLevel<MapInfo>(path + "map1.json"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    IEnumerator PlayMap(string mapName)
    {
        mapOngoing = true;

        float xOffset = 12;
        float yOffset = 3;

        while (mapOngoing)
        {
            List<int> mapNotes = ReadMapNotes(mapName);

            for (int i = 0; i < mapNotes.Count; i++)
            {
                if (mapNotes[i] == (int)Direction.TopLeft)
                {
                    Instantiate(_note, new Vector3(-xOffset, yOffset, 0), Quaternion.identity);
                }
                else if (mapNotes[i] == (int)Direction.MidLeft)
                {
                    Instantiate(_note, new Vector3(-xOffset, 0, 0), Quaternion.identity);
                }
                else if (mapNotes[i] == (int)Direction.BotLeft)
                {
                    Instantiate(_note, new Vector3(-xOffset, -yOffset, 0), Quaternion.identity);
                }
                else if (mapNotes[i] == (int)Direction.TopRight)
                {
                    Instantiate(_note, new Vector3(xOffset, yOffset, 0), Quaternion.identity);
                }
                else if (mapNotes[i] == (int)Direction.MidRight)
                {
                    Instantiate(_note, new Vector3(xOffset, 0, 0), Quaternion.identity);
                }
                else if (mapNotes[i] == (int)Direction.BotRight)
                {
                    Instantiate(_note, new Vector3(xOffset, -yOffset, 0), Quaternion.identity);
                }
                yield return new WaitForSeconds(GetNoteOffset(mapName)[i]);
            }
            mapOngoing = false;
        }
    }

    List<int> ReadMapNotes(string mName)
    {
        List<int> map = new List<int>();
        foreach (int i in MapInfo.getMapNotes(path + mName + ".json"))
        {
            map.Add(i);
        }
        return map;
    }

    List<float> GetNoteOffset(string mName)
    {
        List<float> offset = new List<float>();
        foreach (float i in MapInfo.getMapNoteOffset(path + mName + ".json"))
        {
            offset.Add(i);
        }
        return offset;
    }
    

    
    List<object> GetLevel(string mName)
    {
        List<object> notes = new List<object>();
        foreach (float i in MapInfo.getLevel(path + mName + ".json"))
        {
            notes.Add(i);
        }
        return notes;
    }
    */
}
