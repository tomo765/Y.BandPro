using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionsGenerator : EditorWindow
{
    /// <summary> Assets/Scripts/Generates </summary>
    private static string ScriptsFolderPath => Application.dataPath + "/Scripts/Generates";

    [MenuItem("Editor/InputActions/Generate Input Action")]
    private static void GenerateInputAction() => GenerateInputAction(Application.dataPath + "/InputSystems/KeyBinds/InputSettings.inputactions");


    private static void GenerateInputAction(string assetPath)
    {
        InputActionAsset inputAction = InputActionExtension.LoadAsset(assetPath);

        if (inputAction == null)
        {
            Debug.LogError("InputActionAsset ������܂���B\nFilePath : " + assetPath);
            return;
        }
        CreateAction(inputAction);
        AssetDatabase.Refresh();
        Debug.Log("Completed Create Actions");
    }

    private static void CreateAction(InputActionAsset asset)
    {
        if (!Directory.Exists(ScriptsFolderPath))
        {
            Debug.Log("Scripts directory not found. Create New...");
            Directory.CreateDirectory(ScriptsFolderPath);
        }
        if (!Directory.Exists(ScriptsFolderPath))
        {
            Debug.Log("Scripts directory not found. Create New...");
            Directory.CreateDirectory(ScriptsFolderPath);
        }


        string filePath = string.Format(ScriptsFolderPath + "/InputActions.cs");
        if (File.Exists(filePath) == false)
        {
            Debug.Log(filePath + " not found. Create new...");
            using (var sr = File.Create(filePath))
            {

            }
        }

        using (var sr = new StreamWriter(filePath))
        {
            sr.Write(GenerateClassContent(asset));
        }
    }
    private static string GenerateClassContent(InputActionAsset asset)
    {
        StringBuilder content = new StringBuilder();
        content.Append("//------<���������N���X>------\n");
        content.Append("//  ���̃R�[�h�́AAssets/Editor/InputActionEnumsGenerator.cs �ɂ�莩���������ꂽ�N���X�ł��B\n");
        content.Append("//  ���j���[�� Editor/Generate Input Action Enums ���玩����������܂��B\n");
        content.Append("//------<���������N���X>------\n");
        content.Append("//-----------<����>-----------\n");
        content.Append("//  �N���X�� : InputActionAsset �̖��O\n");
        content.Append("//  �񋓌^�� : Action Maps �̖��O\n");
        content.Append("//  �񋓎q�� : Actions �̖��O\n");
        content.Append("//-----------<����>-----------\n\n");


        content.Append("namespace InputActions");
        content.Append("\n{");
        content.Append(string.Format("\n    public static class {0}", asset.name));
        content.Append("\n    {");

        foreach (var map in asset.actionMaps)
        {
            content.Append(string.Format("\n        public static class {0}", map.name));
            content.Append("\n        {");

            foreach (var action in map.actions)
            {
                content.Append(string.Format("\n            public const string {0} = \"{1}\";", action.name.Replace(" ", ""), action.name));
            }
            content.Append("\n        }\n");
        }
        content.Append("\n    }");

        content.Append("\n}");
        return content.ToString();
    }
}

public static class InputActionExtension
{
    public static InputActionAsset LoadAsset(string filePath)
    {
        try
        {
            // �t�@�C���̓��e�����ׂēǂݍ���
            string jsonContent = File.ReadAllText(filePath);

            // JSON ���� InputActionAsset �Ƀf�V���A���C�Y
            InputActionAsset inputActionAsset = InputActionAsset.FromJson(jsonContent);
            return inputActionAsset;
        }
        catch (IOException ex)
        {
            Debug.LogError("Error reading input actions file: " + ex.Message);
            return null;
        }
    }
}