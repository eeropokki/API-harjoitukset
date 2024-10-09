using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetData();
        }
    }

    // Hakee kaikki tehtävät
    public void GetData()
    {
        print("Haku");
        string uri = "https://localhost:7226/questitems";

        Quest quest = new Quest();

        StartCoroutine(quest.LoadDataFromDatabase(uri, player));
    }
}
