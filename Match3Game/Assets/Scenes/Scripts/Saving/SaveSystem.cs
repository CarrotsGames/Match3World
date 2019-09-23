using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{

   
    public static void SaveMoobling(HappinessManager Moobling)
    {
        string scene = SceneManager.GetActiveScene().name;
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + scene +".Data";
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        FileStream stream = new FileStream(path, FileMode.Create);

        MooblingSave data = new MooblingSave(Moobling);

        formatter.Serialize(stream, data);
        stream.Close();
    }
 
    public static MooblingSave LoadMoobling()
    {
        string scene = SceneManager.GetActiveScene().name;
        string path = Application.persistentDataPath + "/" + scene + ".Data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            MooblingSave data = formatter.Deserialize(stream) as MooblingSave;
            stream.Close();

            return data;
        }
        else
        {
            File.WriteAllText(path, "");

            Debug.Log("Save file created" + path);
            return LoadMoobling();
        }





    }

}
