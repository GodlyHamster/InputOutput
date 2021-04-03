﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] private GameObject noteObject;

    HealthSystem _healthSystem;

    Music musicPlayer;

    string path = "Assets/Resources/Maps/";
    public static string levelName { get; set; }

    public static Dictionary<int, Vector3> Directions = new Dictionary<int, Vector3>
    {
        {0, new Vector3(-14, 3, 0)},
        {1, new Vector3(-14, 0, 0)},
        {2, new Vector3(-14, -3, 0)},
        {3, new Vector3(14, 3, 0)},
        {4, new Vector3(14, 0, 0)},
        {5, new Vector3(14, -3, 0)}
    };

    bool mapOngoing = false;

    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem._HealthUpdated += OnHealthUpdated;

        musicPlayer = GetComponent<Music>();

        noteObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Note.prefab", typeof(GameObject));
        StartCoroutine("PlayMap", levelName);
    }

    IEnumerator PlayMap(string mapName)
    {
        yield return new WaitForSeconds(1f);

        mapOngoing = true;

        string mapText = File.ReadAllText(path + mapName + ".json");
        Map[] map = MapInfo.FromJson<Map>(mapText);

        string musicName = MapInfo.GetMusic<string>(mapText);
        musicPlayer.PlayMusic(musicName);

        int nextNote = 0;
        
        float noteSpeed = MapInfo.GetNoteSpeed<float>(mapText);
        noteObject.GetComponent<Note>().setSpeed(noteSpeed);

        float timeToMid = (11 / noteSpeed) - (0.04f / noteSpeed);

        while (mapOngoing)
        {
            if (musicPlayer.GetTime() >= map[nextNote].time - timeToMid)
            {
                Instantiate(noteObject, Directions[map[nextNote].note], Quaternion.identity);
                nextNote++;
            }
            if (nextNote == map.Length)
            {
                mapOngoing = false;
            }
            yield return null;
        }
    }

    private void Update()
    {
        if (mapOngoing == false && musicPlayer.GetTime() == 0)
        {
            StartCoroutine("EndLevel");
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LevelSelect");
    }

    void OnHealthUpdated(int health)
    {
        if (health <= 0)
        {
            StopAllCoroutines();
            musicPlayer.StartCoroutine("StopMusic");
        }
    }
}

[System.Serializable]
public class Map {
    public int id;
    public int note;
    public float time;
}


