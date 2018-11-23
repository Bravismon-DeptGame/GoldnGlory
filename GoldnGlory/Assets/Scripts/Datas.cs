using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Datas", menuName = "Data Dialog/Datas", order = 2)]
public class Datas : ScriptableObject {

    public string codeDialog;
    public Sprite character;
    public string nameChara;
    [TextArea(10,20)]
    public string dialog;
    //Effect 
    [HideInInspector] public bool doubleChoice;
    [HideInInspector] public string reject;
    [HideInInspector] public string accept;
    [HideInInspector] public Datas[] pointer;
}
