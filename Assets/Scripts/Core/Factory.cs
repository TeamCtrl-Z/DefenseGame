using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singleton<Factory>
{
    /// <summary>
    /// ĳ���� Ǯ
    /// </summary>
    CharacterPool character;

    /// <summary>
    /// �ʱ�ȭ �Լ�
    /// </summary>
    protected override void OnInitialize()
    {
        character = GetComponentInChildren<CharacterPool>();
        if (character != null)
            character.Initialize();
    }

    /// <summary>
    /// ĳ���͸� ��ȯ�ϴ� �Լ�
    /// </summary>
    /// <param name="position">��ȯ ��ġ</param>
    /// <param name="eulerAngles">��ȯ ����</param>
    /// <returns>��ȯ�� ĳ����</returns>
    public CharacterController GetCharacter(Vector2 position, Vector2 eulerAngles)
    {
        return character.GetObject(position, eulerAngles);
    }
}
