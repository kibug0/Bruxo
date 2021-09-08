using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_System
{
    public static void SAve_Game (AudioManager Audio)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string caminho = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(caminho, FileMode.Create);

        SAve_Game data = new SAve_Game(Audio);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SAve_Game LoadPlayer()
    {
        string caminho = Application.persistentDataPath + "/Player.fun";

        if (File.Exists(caminho))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(caminho, FileMode.Open);

            SAve_Game data = formatter.Deserialize(stream) as SAve_Game;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in "+ caminho);
            return null;

        }
    }

    
}
