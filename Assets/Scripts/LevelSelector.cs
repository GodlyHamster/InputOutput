using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public static Dictionary<int, string> Levels = new Dictionary<int, string>
    {
        {0, "Circulation"},
        {1, "Moffumoffu De Yoi no Ja yo"}
    };

    [SerializeField] private GameObject levelTextObj;

    int selectedLevel = 0;

    void Start()
    {
        levelTextObj.GetComponent<Text>().text = Levels[selectedLevel];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedLevel++;
            if (selectedLevel > (Levels.Count - 1))
            {
                selectedLevel = 0;
            }
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedLevel--;
            if (selectedLevel < 0)
            {
                selectedLevel = Levels.Count - 1;
            }
        }
        levelTextObj.GetComponent<Text>().text = Levels[selectedLevel];
    }

    public void StartLevel()
    {
        Level.levelName = Levels[selectedLevel];
        SceneManager.LoadScene("Level");
    }
}
