using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerSelection : MonoBehaviour
{
    ICharacterFactory factory;
    PlayerManager currentPlayer;

    public static PlayerSelection Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SelectPlayer(Pref.CurPlayerId);
        Debug.Log("id HIEN TAI " + Pref.CurPlayerId);
    }

    public void SelectPlayer(int playerNumber)
    {
        currentPlayer = gameObject.GetComponent<PlayerManager>();
        if (currentPlayer == null)
        {
            Debug.LogError("PlayerManager component is missing!");
            return;
        }

        switch (playerNumber)
        {
            case 0:
                factory = new MouseFactory();
                break;
            case 1:
                factory = new SquareFactory();
                break;
            case 2:
                factory = new CircleFactory();
                break;
            case 3:
                factory=new TriangleFactory();
                break;
            default:
                Debug.LogError("Invalid player number.");
                return;
        }

        currentPlayer.SetFactory(factory);

        DestroyCurrentCharacter();
        // Tạo nhân vật mới
        currentPlayer.CreateCharacter();
    }

    // Hàm để hủy đối tượng nhân vật hiện tại
    void DestroyCurrentCharacter()
    {
        var childComponents = currentPlayer.GetComponentsInChildren<Component>();
        foreach (var childComponent in childComponents)
        {
            // Kiểm tra xem đối tượng con có thực hiện interface Character không
            if (childComponent is Character)
            {
                // Nếu có, hủy đối tượng
                Destroy(childComponent.gameObject);
            }
        }
    }
}