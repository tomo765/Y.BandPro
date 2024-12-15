using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpritePreviewAttribute))]
public class SpriteDrawer : PropertyDrawer
{
    private static readonly float Margin = EditorGUIUtility.standardVerticalSpacing;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // �ʏ�̃v���p�e�B��`��
        position.height = EditorGUI.GetPropertyHeight(property, label);
        // PreviewAttribute�̎擾
        var previewAttribute = (SpritePreviewAttribute)attribute;
        EditorGUI.PropertyField(position, property, label);
        //�X�v���C�g���K�p����Ă��鎞�����\���̕����Ƃ�
        previewAttribute.Height = property.objectReferenceValue == null ? 0 : SpritePreviewAttribute.HEIGHT;

        if (property.objectReferenceValue == null) { return; }

        // �v���r���[�p�e�N�X�`���̎擾
        var texture = AssetPreview.GetAssetPreview(property.objectReferenceValue);
        if (texture == null) { return; }

        var width = previewAttribute.Height * texture.width / texture.height;

        // �E�񂹂ɂ��ĉ摜��\��
        // �e�N�X�`����\������ʒu���v�Z
        var imageRect = new Rect
        {
            x = position.xMax - width - Margin,
            y = position.y + position.height + Margin,
            width = width,
            height = previewAttribute.Height
        };

        // �摜��\��
        GUI.DrawTexture(imageRect, texture);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var previewAttribute = (SpritePreviewAttribute)attribute;
        return previewAttribute.Height + EditorGUI.GetPropertyHeight(property, label) + Margin * 2;
    }
}