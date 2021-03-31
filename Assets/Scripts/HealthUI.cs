using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private GameObject HealthController;
    HealthSystem healthSystem;

    [SerializeField] private GameObject healthBarObject;
    [SerializeField] float maxHealthbarSize;

    private int oldHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        var healthBar = healthBarObject.transform as RectTransform;
        healthBar.sizeDelta = new Vector2(maxHealthbarSize, healthBar.sizeDelta.y);

        healthSystem = HealthController.GetComponent<HealthSystem>();
        healthSystem._HealthUpdated += OnHealthUpdated;
    }

    void OnHealthUpdated(int health)
    {
        Debug.Log(health);

        StartCoroutine("UpdateHealthbar", health);

        if (health <= 0)
        {
            Debug.Log("You failed the level");
        }
    }

    IEnumerator UpdateHealthbar(int health)
    {
        var healthBar = healthBarObject.transform as RectTransform;
        
        int differenceHealth = health - oldHealth;
        int positiveDif = differenceHealth;
        if (positiveDif < 0)
        {
            positiveDif = -positiveDif;
        }

        for (int i = 0; i < positiveDif; i++)
        {
            healthBar.sizeDelta += new Vector2((differenceHealth / positiveDif) * (maxHealthbarSize / 100), 0);
            oldHealth = health;
            yield return new WaitForSeconds(0.01f);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
