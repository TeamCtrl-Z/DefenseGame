using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singleton<Factory>
{
    /// <summary>
    /// 캐릭터 풀
    /// </summary>
    CharacterPool character;

    /// <summary>
    /// 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        character = GetComponentInChildren<CharacterPool>();
        if (character != null)
            character.Initialize();
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public CharacterController GetCharacter(Vector2 position, Vector2 eulerAngles)
    {
        return character.GetObject(position, eulerAngles);
    }
}
