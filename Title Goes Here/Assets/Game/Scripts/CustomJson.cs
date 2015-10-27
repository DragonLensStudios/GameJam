using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class CustomJson : MonoBehaviour
{
    public string json_name;
    public string json_filetype = ".json";
    public TextAsset json_asset;

    public void Start()
    {
/*        var lol = scriptobject.GetClass();
        if (scriptobject != null)
        {
            TestSerial(scriptobject);
            Debug.Log(lol);
        }*/
//        var test = new BaseJson();
//        TestSerial(test);
    }

    public void TestSerial<T>(T _typeBaseJson)
    {
        Debug.Log(_typeBaseJson.GetType());
        var a = _typeBaseJson.GetType();
        Debug.Log("CLASS: " + a);
        if (a == System.Type.GetType("BaseJson"))
        {
            Debug.Log("This is a base json");
        }
        
//        if (_typeBaseJson is BaseJson)
//        {
//            var main = (BaseJson) _typeBaseJson;
//        }
/*        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        string test = JsonConvert.SerializeObject(_typeBaseJson, Formatting.Indented, settings);

        Debug.Log(test);*/

//        if (File.Exists("Assets/Resources/" + json_name + ".json") == false)
//        {
//            File.Create("Assets/Resources/" + json_name + ".json");
//            json_asset = Resources.Load(json_name) as TextAsset;
//        
//        }
//        else
//        {
//            Debug.Log("it exists!");
//            json_asset = Resources.Load(json_name) as TextAsset;
//        }

//        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
//        var _class = Serialize<System.Object>(obj);

//        Debug.Log(_class.GetType());
//        string serialized = JsonConvert.SerializeObject(, Formatting.Indented,settings);
//        File.WriteAllText("Assets/Game/Resources/Testjson.json",serialized);


    }
}
