using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public SaveData SaveData { get; private set; }
    public bool _isLoad { get; private set; }
    private string _path;
    private string _data;
   

    public static SaveSystem Instance;
    void Awake()
    {
        SaveData = new SaveData();
        _path = Application.dataPath + "/savefile.txt";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _path = Path.Combine(Application.persistentDataPath, "save.json");
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

        SaveData = new SaveData(position, rotation, coins, lifes);
        _data = JsonConvert.SerializeObject(SaveData, Formatting.Indented);
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
            SaveData = JsonConvert.DeserializeObject<SaveData>(_data);
            _isLoad = true;
        }
        else
        {
            Debug.Log("No save file found");
          
        }
    }

    public void LoadPlayerInfo()
    {
        if(_player == null)
        {
            FoundPlayer();
        }
        if (_isLoad && _player != null)
        {
            _player.position = new Vector3(SaveData.position[0], SaveData.position[1], SaveData.position[2]);
            _player.rotation = new Quaternion(SaveData.rotation[0], SaveData.rotation[1], SaveData.rotation[2], SaveData.rotation[3]);

            LifeController.instance.SetLives(SaveData.lifes);
            CoinsManager.instance.SetCoins(SaveData.coins);

            _isLoad = false;
        }

    }

    public void FoundPlayer()
    {
        _player = PlayerController.instance.transform;
    }
}


