using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components;

public class DisplayOfText : MonoBehaviour
{
    [SerializeField] private LocalizeStringEvent Text;
    private Text _UIText;

    private void Start()
    {
        _UIText = Text.GetComponent<Text>();
        if (_UIText == null) throw new System.ArgumentNullException(nameof(_UIText));
    }

    public void Display(string table, string key)
    {
        if (_UIText.enabled == false)
            _UIText.enabled = true;

        Text.StringReference.SetReference(table, key);
        Text.StringReference.RefreshString();
    }

    public void DisplayNull()
    {
        if (_UIText.enabled == true)
            _UIText.enabled = false;
    }
}
