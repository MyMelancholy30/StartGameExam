using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSetterCanvas : MonoBehaviour
{
    public GameObject inputname;
    public GameObject selectchar;

    [SerializeField]
    private TMP_InputField _input;

    private void Awake()
    {
        _input.onSubmit.AddListener(_input_OnSubmit);
    }

    private void _input_OnSubmit(string text)
    {
        PlayerNameTracker.SetName(text);
        inputname.SetActive(false);
        selectchar.SetActive(true);
    }
}
