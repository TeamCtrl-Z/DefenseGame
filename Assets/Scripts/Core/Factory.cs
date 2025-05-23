using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singleton<Factory>
{
    /// <summary>
    /// 캐릭터 풀
    /// </summary>
    FairyPool fairy;

    /// <summary>
    /// 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        fairy = GetComponentInChildren<FairyPool>();
        if (fairy != null)
            fairy.Initialize();
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public FairyController GetCharacter(Vector2 position, Vector2 eulerAngles)
    {
        return fairy.GetObject(position, eulerAngles);
    }
}
