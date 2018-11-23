using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Scenes", menuName = "Data Dialog/Scenes", order = 1)]
public class Scenes : ScriptableObject {
    public string sceneName;
    public string codeScene;
    public Sprite background;
    public Datas head;
    public Datas tail;
}
