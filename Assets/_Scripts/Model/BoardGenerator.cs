using System;
using System.Xml;
using UnityEngine;
using Random = System.Random;

public class BoardGenerator : MonoBehaviour
{
	public int rows;
	public int columns;
    public GameObject floorTile;
    public GameObject wallTile;
    public GameObject nothing;
    public GameObject board;
    public Transform boardHolder;
    Random rng;
    XmlElement root;

	public BoardGenerator ()
	{
        rng = new Random();
        XmlDocument roomFile = new XmlDocument();
        //roomFile.Load("Rooms.xml");
		roomFile.LoadXml(getXML());
        root = roomFile.DocumentElement;
	}

    public void generate()
    {
        board = new GameObject("Board");
        boardHolder = board.transform;
        int[,] mock = new int[rows, columns];
        int startRow = rows / 2;
        int startColumn = columns / 2;
        // initialize mock array to hold all -1
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                mock[i, j] = -1;
            }
        }

        // set starting room in mock array
        mock[startRow, startColumn] = 0;
        // set boss room above start room
        mock[startRow - 1, startColumn] = 1;

        addSurroundingRooms(startRow, startColumn, mock);

        /*string blah = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                blah += mock[i, j];
            }
            blah += '\n';
        }
        Debug.Log(blah);*/

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                XmlNode thisRoom = root.SelectNodes("/MAP/ROOM[@ID='" + mock[i, j] + "']").Item(0);
                GameObject instance;
                Room newRoom = ScriptableObject.CreateInstance<Room>();
                if (mock[i, j] == -1) // not part of the map
                {
                    newRoom.with(thisRoom, false, false, false, false, floorTile, wallTile, nothing);
                    instance = newRoom.getRoom();//, new Vector3(j * Int32.Parse(thisRoom.Attributes["WIDTH"].InnerText), i * Int32.Parse(thisRoom.Attributes["HEIGHT"].InnerText), 0f), Quaternion.identity) as GameObject;
                    instance.transform.position = new Vector3(j * Int32.Parse(thisRoom.Attributes["WIDTH"].InnerText), i * Int32.Parse(thisRoom.Attributes["HEIGHT"].InnerText), 0f);
                    instance.transform.SetParent(boardHolder);
                    continue;
                }

                bool n = false;
                if (i > 0 && mock[i - 1, j] >= 0)
                {
                    n = true;
                }

                bool s = false;
                if (i < rows - 1 && mock[i + 1, j] >= 0)
                {
                    s = true;
                }

                bool e = false;
                if (j < columns - 1 && mock[i, j + 1] >= 0)
                {
                    e = true;
                }

                bool w = false;
                if (j > 0 && mock[i, j - 1] >= 0)
                {
                    w = true;
                }
                newRoom.with(thisRoom, n, s, e, w, floorTile, wallTile, nothing);
                instance = newRoom.getRoom();//, new Vector3(j * Int32.Parse(thisRoom.Attributes["WIDTH"].InnerText), i * Int32.Parse(thisRoom.Attributes["HEIGHT"].InnerText), 0f), Quaternion.identity) as GameObject;
                instance.transform.position = new Vector3(j * Int32.Parse(thisRoom.Attributes["WIDTH"].InnerText), i * Int32.Parse(thisRoom.Attributes["HEIGHT"].InnerText), 0f);
                instance.transform.SetParent(boardHolder);
                
            }
        }
    }

    private void addSurroundingRooms (int roomRow, int roomColumn, int[,] mock)
    {
        
        // adding rooms to the left
        if (roomColumn > 0 && rng.Next(2) == 1 && mock[roomRow, roomColumn - 1] == -1)
        {
            
            mock[roomRow, roomColumn - 1] = rng.Next(2, Int32.Parse(root.GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow, roomColumn - 1, mock);
        }
        // adding rooms to the right
        if (roomColumn < (columns - 1) && rng.Next(2) == 1 && mock[roomRow, roomColumn + 1] == -1)
        {
            mock[roomRow, roomColumn + 1] = rng.Next(2, Int32.Parse(root.GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow, roomColumn + 1, mock);
        }
        // adding rooms above
        if (roomRow > 0 && rng.Next(2) == 1 && mock[roomRow - 1, roomColumn] == -1)
        {
            mock[roomRow - 1, roomColumn] = rng.Next(2, Int32.Parse(root.GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow - 1, roomColumn, mock);
        }
        // adding rooms below
        if (roomRow < (rows - 1) && rng.Next(2) == 1 && mock[roomRow + 1, roomColumn] == -1)
        {
            mock[roomRow + 1, roomColumn] = rng.Next(2, Int32.Parse(root.GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow + 1, roomColumn, mock);
        }
    }

    public void deactivate()
    {
        Destroy(board.gameObject);
    }

    private string getXML ()
    {
        return (
            "<MAP NUMROOMS='4'>" +
            "<ROOM ID='-1' HEIGHT='7' WIDTH='9'>" +
                "<LAYOUT>" +
                    "NNNNNNNNN" +
                    "NNNNNNNNN" +
                    "NNNNNNNNN" +
                    "NNNNNNNNN" +
                    "NNNNNNNNN" +
                    "NNNNNNNNN" +
                    "NNNNNNNNN" +
                "</LAYOUT>" +
            "</ROOM>" +
            "<ROOM ID='0' HEIGHT='7' WIDTH='9'>" +
                "<LAYOUT>" +
                    "WWWWWWWWW" +
                    "WFFFFFFFW" +
                    "WFWFFFWFW" +
                    "WFFFFFFFW" +
                    "WFWFFFWFW" +
                    "WFFFFFFFW" +
                    "WWWWWWWWW" +
                "</LAYOUT>" +
            "</ROOM>" +
            "<ROOM ID='1' HEIGHT='7' WIDTH='9'>" +
                "<LAYOUT>" +
                    "WWWWWWWWW" +
                    "WFFFFFFFW" +
                    "WFFFFFFFW" +
                    "WFFFFFFFW" +
                    "WFFFFFFFW" +
                    "WFFFFFFFW" +
                    "WWWWWWWWW" +
                "</LAYOUT>" +
            "</ROOM>" +
            "<ROOM ID='2' HEIGHT='7' WIDTH='9'>" +
                "<LAYOUT>" +
                    "WWWWWWWWW" +
                    "WFFFFFFFW" +
                    "WFFFFFFFW" +
                    "WFFFWFFFW" +
                    "WFFFFFFFW" +
                    "WFFFFFFFW" +
                    "WWWWWWWWW" +
                "</LAYOUT>" +
            "</ROOM>" +
            "<ROOM ID='3' HEIGHT='7' WIDTH='9'>" +
                "<LAYOUT>" +
                    "WWWWWWWWW" +
                    "WFFFFFFFW" +
                    "WFWFFFWFW" +
                    "WFFFFFFFW" +
                    "WFWWWWWFW" +
                    "WFFFFFFFW" +
                    "WWWWWWWWW" +
                "</LAYOUT>" +
            "</ROOM>" +
            "</MAP>"
            );
    }
}

