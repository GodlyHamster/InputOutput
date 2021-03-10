using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class MapInfo
{
    public int[] notes;
    public float[] offset;
    //public string musicPath;
    //public object[] level;
    //public int note;
    //public float offset;

    
    public static int[] getMapNotes(string mapPath)
    {
        string json = File.ReadAllText(mapPath);

        MapInfo map = JsonUtility.FromJson<MapInfo>(json);
        return map.notes;
    }

    public static float[] getMapNoteOffset(string mapPath)
    {
        string json = File.ReadAllText(mapPath);

        MapInfo map = JsonUtility.FromJson<MapInfo>(json);
        return map.offset;
    }
    

    /*
    public static object[] getLevel(string mapPath)
    {
        string json = File.ReadAllText(mapPath);

        MapInfo map = JsonUtility.FromJson<MapInfo>(json);
        return map.level;
    }
    */
}
