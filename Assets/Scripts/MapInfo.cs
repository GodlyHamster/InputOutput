using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MapInfo
{

    public static T[] GetLevel<T>(string json)
    {
        string mapText = File.ReadAllText(json);

        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(mapText);
        Debug.Log(mapText);

        return wrapper.Level;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Level;
        public int note;
        public float offset;
    }
}
