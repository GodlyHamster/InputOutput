﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapInfo
{

    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Level;
    }

    public static T GetMusic<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Music;
    }

    public static T GetNoteSpeed<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.NoteSpeed;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Level;
        public T Music;
        public T NoteSpeed;
    }
}
