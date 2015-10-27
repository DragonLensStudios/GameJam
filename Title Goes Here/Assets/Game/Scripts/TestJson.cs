using System.Collections.Generic;
using System.Diagnostics;

public class TestJson
{
    public string Name =  "Taco";
    public int ID;
    public List<string> StringList;

    public void Awesome()
    {
        Debug.WriteLine("lol");
    }
}

public class TestJson2 : TestJson
{
    public string SuperWoW;
    public bool Tacos = true;
}
