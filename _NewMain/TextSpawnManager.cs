using UnityEngine;
using UnityEngine.UI;

public class TextSpawnManager : MonoBehaviour
{
    public GameObject textPrefab;
    private static TextSpawnManager instance;
    public RectTransform cavasTransform;
    public static TextSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TextSpawnManager>();
            }
            return instance;
        }
    }
    public void SpawnText(Vector3 _spawnPoint, string _message)
    {
        GameObject sct = (GameObject)Instantiate(textPrefab, _spawnPoint, Quaternion.identity);
        sct.transform.SetParent(cavasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        sct.gameObject.GetComponent<Text>().text = _message;
    }
    public void SpawnTextCenter(string _message)
    {
        Instantiate(textPrefab, transform);
    }


}
