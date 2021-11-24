using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color teamColor;
    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {

        Instance = this;
        DontDestroyOnLoad(gameObject);
        }

        LoadColor();
    }
    [SerializeField]
    public class SaveData
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = this.teamColor;  // this will refer to the class in which scope it is.

        string json = JsonUtility.ToJson(data);   // converted the data to the Json Format

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);  // this writed the string to the file
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path); // this line will read the contents of the file and stores it in string 

            SaveData data = JsonUtility.FromJson<SaveData>(json);  // this will convert the string file in Json format to the SaveData type object

            this.teamColor = data.teamColor;
        }
    }
}
