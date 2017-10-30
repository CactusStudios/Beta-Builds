using UnityEngine;
using System.Xml;
using System.Collections;

public class Room
{
    public Room (XmlNode thisRoom, bool n, bool s, bool e, bool w)
    {
        string whatToMake = "Creating room with layout:\n" +
            thisRoom["LAYOUT"].InnerText;
        Debug.Log(whatToMake);
    }
}
