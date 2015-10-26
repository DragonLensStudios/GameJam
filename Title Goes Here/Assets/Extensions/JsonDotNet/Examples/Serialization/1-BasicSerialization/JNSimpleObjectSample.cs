//### Sample objects are in the 999-ExampleModels/JNExampleModels.cs
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace DustinHorne.Json.Examples
{
    /// <summary>
    /// Example of serializing and deserializing a simple object
    /// </summary>
    public class JNSimpleObjectSample : MonoBehaviour
    {
        public string json_name;
        public string json_filetype = ".json";
        public TextAsset json_asset;

        public void Start()
        {
            Sample();
        }

        public void Sample()
        {
            if (File.Exists("Assets/Resources/" + json_name + ".json") == false)
            {
                File.Create("Assets/Resources/" + json_name +".json");
                json_asset = Resources.Load(json_name) as TextAsset;

            }
            else
            {
                Debug.Log("it exists!");
                json_asset = Resources.Load(json_name) as TextAsset;
            }
            //Create an object to serialize
//                        var original = new JNSimpleObjectModel
//                            {
//                                IntValue = 5,
//                                FloatValue = 4.98f,
//                                StringValue = "Simple Object",
//                                IntList = new List<int> { 4, 7, 25, 34 },
//                                ObjectType = JNObjectType.BaseClass
//                            };

                        var original = new TestJson
                        {
                            ID = 5
                            
                        };

            //This string is the JSON representation of the object
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

//            string serialized = JsonConvert.SerializeObject(new TestJson2 {ID = 5, Name = "Super Name", StringList = new List<string> {"LOL","WOW"},SuperWoW = "OMG DUDE" },Formatting.Indented,settings);
            string serialized = JsonConvert.SerializeObject(new TestJson {ID = 5, Name = "Super Name", StringList = new List<string> {"LOL","WOW"} },Formatting.Indented,settings);

            File.WriteAllText("Assets/Resources/" + json_name + ".json", serialized);

//            if (File.Exists("Assets/Resources/" + json_name + ".json") == false)
//            {
//                File.Create("Assets/Resources/" + json_name + ".json");
//            }
//          else
//          {
//              File.WriteAllText("Assets/Resources/" + json_name + ".json",serialized);
//          }
//            File.WriteAllText("Assets/Game/Resources/Testjson.json",serialized);

            //Now we can deserialize this string back into an object


//            var newobject = JsonConvert.DeserializeObject<JNSimpleObjectModel>(serialized);
            var newobject = JsonConvert.DeserializeObject<TestJson>(serialized,settings);

//            var newobject = JsonConvert.DeserializeObject<TestJson2>(json_asset.text,settings);

//            Debug.Log(serialized);
//
//            Debug.Log("DESERIALIZED: NAME: " + newobject.Name + " ID: " + newobject.ID + " SuperWOW: " + newobject.SuperWoW );
        }
    }
}




