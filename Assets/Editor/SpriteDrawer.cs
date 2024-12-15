using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpritePreviewAttribute))]
public class SpriteDrawer : PropertyDrawer
{
    private static readonly float Margin = EditorGUIUtility.standardVerticalSpacing;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // 通常のプロパティを描画
        position.height = EditorGUI.GetPropertyHeight(property, label);
        // PreviewAttributeの取得
        var previewAttribute = (SpritePreviewAttribute)attribute;
        EditorGUI.PropertyField(position, property, label);
        //スプライトが適用されている時だけ表示の幅をとる
        previewAttribute.Height = property.objectReferenceValue == null ? 0 : SpritePreviewAttribute.HEIGHT;

        if (property.objectReferenceValue == null) { return; }

        // プレビュー用テクスチャの取得
        var texture = AssetPreview.GetAssetPreview(property.objectReferenceValue);
        if (texture == null) { return; }

        var width = previewAttribute.Height * texture.width / texture.height;

        // 右寄せにして画像を表示
        // テクスチャを表示する位置を計算
        var imageRect = new Rect
        {
            x = position.xMax - width - Margin,
            y = position.y + position.height + Margin,
            width = width,
            height = previewAttribute.Height
        };

        // 画像を表示
        GUI.DrawTexture(imageRect, texture);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var previewAttribute = (SpritePreviewAttribute)attribute;
        return previewAttribute.Height + EditorGUI.GetPropertyHeight(property, label) + Margin * 2;
    }
}