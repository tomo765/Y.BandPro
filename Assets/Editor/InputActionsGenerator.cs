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
            Debug.LogError("InputActionAsset がありません。\nFilePath : " + assetPath);
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
        content.Append("//------<自動生成クラス>------\n");
        content.Append("//  このコードは、Assets/Editor/InputActionEnumsGenerator.cs により自動生成されたクラスです。\n");
        content.Append("//  メニューの Editor/Generate Input Action Enums から自動生成されます。\n");
        content.Append("//------<自動生成クラス>------\n");
        content.Append("//-----------<説明>-----------\n");
        content.Append("//  クラス名 : InputActionAsset の名前\n");
        content.Append("//  列挙型名 : Action Maps の名前\n");
        content.Append("//  列挙子名 : Actions の名前\n");
        content.Append("//-----------<説明>-----------\n\n");


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
            // ファイルの内容をすべて読み込む
            string jsonContent = File.ReadAllText(filePath);

            // JSON から InputActionAsset にデシリアライズ
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