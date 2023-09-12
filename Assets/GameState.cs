using UnityEngine;

public class GameState
{
    public static GameState Get()
    {
        return Istance;
    }

    private GameState() { }

    private GameObject playerGameObject;

    public GameObject GetPlayer()
    { 
        return playerGameObject;
    }
    // Start is called before the first frame update
    public void Start()
    {
        playerGameObject = MonoBehaviour.FindObjectOfType<PlayerScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static GameState Istance = new GameState();
}
