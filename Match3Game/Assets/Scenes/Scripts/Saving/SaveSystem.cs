using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static bool NewSave;

    public static void SaveMoobling(HappinessManager Moobling)
    {
        string scene = SceneManager.GetActiveScene().name;
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + scene +".Data";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
            FileStream CreateStream = File.Open(path, FileMode.Create);
            MooblingSave data = new MooblingSave(Moobling);
            formatter.Serialize(CreateStream, data);

            CreateStream.Close();
            return;
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
   
            MooblingSave data = new MooblingSave(Moobling);
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
 
    public static MooblingSave LoadMoobling()
    {
        string scene = SceneManager.GetActiveScene().name;
        string path = Application.persistentDataPath + "/" + scene + ".Data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            if(stream.Length < 1)
            {
                stream.Close();
                NewSave = true;
                return null;
            }
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
    public static void SaveChallenge(ChallengeComplete Ch)
    {
        string scene = SceneManager.GetActiveScene().name;
       
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + Ch.ChallengeName + ".Data";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        FileStream stream = new FileStream(path, FileMode.Create);

        ChallengeSave data = new ChallengeSave(Ch);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ChallengeSave LoadChallenge(string ChallengeName)
    {
        string scene = SceneManager.GetActiveScene().name;
        string path = Application.persistentDataPath + "/" + ChallengeName + ".Data";
        if (File.Exists(path))
        {
        
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
         
            BinaryFormatter formatter = new BinaryFormatter();
            if (stream.Length < 1)
            {
                stream.Close();
                return null;
            }
            else
            {
                ChallengeSave data = formatter.Deserialize(stream) as ChallengeSave;
                ChallengeComplete.ChallengeList = data.CompletedLevels;

                stream.Close();


                return data;
            }
           
         }
        else
        {
            File.WriteAllText(path, "");

            Debug.Log("Save file created" + path);
            return LoadChallenge(ChallengeName);
        }

    }
}
