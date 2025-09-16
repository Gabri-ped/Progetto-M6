using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private SaveData _saveData;
    private string _path;
    private string _data;

    public static SaveSystem Instance { get; private set; }
    void Awake()
    {
        _saveData = new SaveData();
        _path = Application.dataPath + "/savefile.txt";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        float[] position = new float[3];
        position[0] = _player.position.x;
        position[1] = _player.position.y;
        position[2] = _player.position.z;
        float[] rotation = new float[4];
        rotation[0] = _player.rotation.x;
        rotation[1] = _player.rotation.y;
        rotation[2] = _player.rotation.z;
        rotation[3] = _player.rotation.w;
        int coins = CoinsManager.instance.totalCoins;
        int lifes = LifeController.instance.currentLives;

        _saveData = new SaveData(position, rotation, coins, lifes);
        _data = JsonConvert.SerializeObject(_saveData, Formatting.Indented);
        try
        {
            File.WriteAllText(_path, _data);
        }
        catch
        {
            Debug.Log("Error saving file");
        }
    }

    public void LoadGame()
    {
        if (File.Exists(_path))
        {
            _data = File.ReadAllText(_path);
            _saveData = JsonConvert.DeserializeObject<SaveData>(_data);
            _player.transform.position = new Vector3(_saveData.position[0], _saveData.position[1], _saveData.position[2]);
            _player.transform.rotation = new Quaternion(_saveData.rotation[0], _saveData.rotation[1], _saveData.rotation[2], _saveData.rotation[3]);
            LifeController.instance.currentLives = _saveData.lifes;
            CoinsManager.instance.totalCoins = _saveData.coins;
        }
        else
        {
            Debug.Log("No save file found");
          
        }
    }
}


