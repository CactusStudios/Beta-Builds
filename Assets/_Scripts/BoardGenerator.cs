using System;
using System.Xml;
using UnityEngine;
using Random = System.Random;

public class BoardGenerator : MonoBehaviour
{
	public int rows;
	public int columns;
	//Room[,] rooms;
    Random rng;
    XmlDocument roomFile;

	public BoardGenerator ()
	{
        rng = new Random();
        roomFile = new XmlDocument();
        roomFile.Load("Rooms.xml");
        // DO NOT SET ROWS/COLUMNS LESS THAN 2
        rows = 3;
		columns = 3;
        int startRow = rows / 2;
        int startColumn = columns / 2;
		//rooms = new Room[rows, columns];

        int[,] mock = new int[rows, columns];
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

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(mock[i, j]);
            }
            Console.Write('\n');
        }
	}

    private void addSurroundingRooms (int roomRow, int roomColumn, int[,] mock)
    {
        // adding rooms to the left
        if (roomColumn > 0 && rng.Next(2) == 1 && mock[roomRow, roomColumn - 1] == -1)
        {
            mock[roomRow, roomColumn - 1] = rng.Next(2, Int32.Parse(roomFile.GetElementById("MAP").GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow, roomColumn - 1, mock);
        }
        // adding rooms to the right
        if (roomColumn < (columns - 1) && rng.Next(2) == 1 && mock[roomRow, roomColumn + 1] == -1)
        {
            mock[roomRow, roomColumn + 1] = rng.Next(2, Int32.Parse(roomFile.GetElementById("MAP").GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow, roomColumn + 1, mock);
        }
        // adding rooms above
        if (roomRow > 0 && rng.Next(2) == 1 && mock[roomRow - 1, roomColumn] == -1)
        {
            mock[roomRow - 1, roomColumn] = rng.Next(2, Int32.Parse(roomFile.GetElementById("MAP").GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow - 1, roomColumn, mock);
        }
        // adding rooms below
        if (roomRow < (rows - 1) && rng.Next(2) == 1 && mock[roomRow + 1, roomColumn] == -1)
        {
            mock[roomRow + 1, roomColumn] = rng.Next(2, Int32.Parse(roomFile.GetElementById("MAP").GetAttribute("NUMROOMS")));
            addSurroundingRooms(roomRow + 1, roomColumn, mock);
        }
    }
}

