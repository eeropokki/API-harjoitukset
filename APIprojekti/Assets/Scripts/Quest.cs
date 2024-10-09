using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

[System.Serializable]
public class Quest
{
    public int Id { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public int Reward { set; get; }

    public Quest(){}

    public Quest(int id, string name, string description, int reward)
    {
        Id = id;
        Name = name;
        Description = description;
        Reward = reward;
    }

    public IEnumerator LoadDataFromDatabase(string uri, Player player)
    {
        string json;
        // Luo HTTP GET olion
        using UnityWebRequest request = UnityWebRequest.Get(uri);
        // Kommunikoi API-palvelimen kanssa
        yield return request.SendWebRequest();

        // Tuliko nettivirhe? 
        if (request.error != null)
        {
            Debug.LogError($"Nettivirhe: {request.error}");
        }
        else 
        {
            json = request.downloadHandler.text;

            Quest[] quests = JsonConvert.DeserializeObject<Quest[]>(json);

            // Tulostetaan tehtävän ID ja nimi
            Debug.Log($"Id: {quests[0].Id}, Name: {quests[0].Name}, Reward: {quests[2].Reward}");
            Debug.Log($"Id: {quests[1].Id}, Name: {quests[1].Name}, Reward: {quests[2].Reward}");
        }
    }
}
