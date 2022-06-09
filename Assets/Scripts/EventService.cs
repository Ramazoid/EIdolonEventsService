using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EventService : MonoBehaviour
{
    private CoolDown coolDown;
    private bool go;
    public List<Events> events = new List<Events>();

    // Start is called before the first frame update
    void Start()
    {
        coolDown = GetComponent<CoolDown>();
        if(PlayerPrefs.HasKey("events"))
        {
            events = JsonConvert.DeserializeObject<List<Events>>(PlayerPrefs.GetString("events"));
                go = true;
            PlayerPrefs.DeleteKey("events");
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (events.Count > 0)
        {
            if (go)
            {
                
                
                StartCoroutine(WaitAndPrint());
                go = false;
            }
        }
    }
    public void TrackEvent(string type, string data)
    {
        var e = new Events(type, data);
        events.Add(e);
        go = true;

    }
    private IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(coolDown.value);

        string json = JsonConvert.SerializeObject(events, Formatting.Indented);
        print("sending: " + json);
        WWWForm form = new WWWForm();
        form.AddField("events", json);
        using (UnityWebRequest www = UnityWebRequest.Post("http://www.gopogle.com", form))
        {
            yield return www.SendWebRequest();
            go = true;
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                PlayerPrefs.SetString("events", json);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
