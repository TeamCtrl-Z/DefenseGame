using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSummonUI : MonoBehaviour
{
    [SerializeField]
    private Button monsterButton;

    /// <summary>
    /// 스폰 메소드 Dictionary
    /// </summary>
    private Dictionary<SpawnType, Action<Vector2, float>> spawnMethod;

    public SpawnType spawnType;

    /// <summary>
    /// ChapterManager를 초기화 하는 함수
    /// </summary>
    private void Start()
    {
        spawnMethod = new Dictionary<SpawnType, Action<Vector2, float>>
        {
            { SpawnType.Enemy000, (pos, angle) => Factory.Instance.GetEnemy_000(pos, angle) },
            { SpawnType.Enemy001, (pos, angle) => Factory.Instance.GetEnemy_001(pos, angle) },
            { SpawnType.Enemy002, (pos, angle) => Factory.Instance.GetEnemy_002(pos, angle) },
            { SpawnType.Enemy003, (pos, angle) => Factory.Instance.GetEnemy_003(pos, angle) },
            { SpawnType.Enemy004, (pos, angle) => Factory.Instance.GetEnemy_004(pos, angle) },
            { SpawnType.Enemy005, (pos, angle) => Factory.Instance.GetEnemy_005(pos, angle) },
            { SpawnType.Enemy006, (pos, angle) => Factory.Instance.GetEnemy_006(pos, angle) },
            { SpawnType.Enemy007, (pos, angle) => Factory.Instance.GetEnemy_007(pos, angle) },
            { SpawnType.Enemy008, (pos, angle) => Factory.Instance.GetEnemy_008(pos, angle) },
            { SpawnType.Enemy009, (pos, angle) => Factory.Instance.GetEnemy_009(pos, angle) },
            { SpawnType.Enemy010, (pos, angle) => Factory.Instance.GetEnemy_010(pos, angle) },
            { SpawnType.Enemy011, (pos, angle) => Factory.Instance.GetEnemy_011(pos, angle) },
            { SpawnType.Enemy012, (pos, angle) => Factory.Instance.GetEnemy_012(pos, angle) },
            { SpawnType.Enemy013, (pos, angle) => Factory.Instance.GetEnemy_013(pos, angle) },
            { SpawnType.Enemy014, (pos, angle) => Factory.Instance.GetEnemy_014(pos, angle) },
            { SpawnType.Enemy015, (pos, angle) => Factory.Instance.GetEnemy_015(pos, angle) },
            { SpawnType.Enemy016, (pos, angle) => Factory.Instance.GetEnemy_016(pos, angle) },
            { SpawnType.Enemy017, (pos, angle) => Factory.Instance.GetEnemy_017(pos, angle) },
            { SpawnType.Enemy018, (pos, angle) => Factory.Instance.GetEnemy_018(pos, angle) },
            { SpawnType.Enemy019, (pos, angle) => Factory.Instance.GetEnemy_019(pos, angle) },
            { SpawnType.Enemy020, (pos, angle) => Factory.Instance.GetEnemy_020(pos, angle) },
            { SpawnType.Enemy021, (pos, angle) => Factory.Instance.GetEnemy_021(pos, angle) },
            { SpawnType.Enemy022, (pos, angle) => Factory.Instance.GetEnemy_022(pos, angle) },
            { SpawnType.Enemy023, (pos, angle) => Factory.Instance.GetEnemy_023(pos, angle) },
            { SpawnType.Enemy024, (pos, angle) => Factory.Instance.GetEnemy_024(pos, angle) },
            { SpawnType.Enemy025, (pos, angle) => Factory.Instance.GetEnemy_025(pos, angle) },
            { SpawnType.Enemy026, (pos, angle) => Factory.Instance.GetEnemy_026(pos, angle) },
            { SpawnType.Enemy027, (pos, angle) => Factory.Instance.GetEnemy_027(pos, angle) },
            { SpawnType.Enemy028, (pos, angle) => Factory.Instance.GetEnemy_028(pos, angle) },
            { SpawnType.Enemy029, (pos, angle) => Factory.Instance.GetEnemy_029(pos, angle) },
            { SpawnType.Enemy030, (pos, angle) => Factory.Instance.GetEnemy_030(pos, angle) },
            { SpawnType.Enemy031, (pos, angle) => Factory.Instance.GetEnemy_031(pos, angle) },
            { SpawnType.Enemy100, (pos, angle) => Factory.Instance.GetEnemy_100(pos, angle) },
            { SpawnType.Enemy101, (pos, angle) => Factory.Instance.GetEnemy_101(pos, angle) },
            { SpawnType.Enemy102, (pos, angle) => Factory.Instance.GetEnemy_102(pos, angle) },
            { SpawnType.Enemy103, (pos, angle) => Factory.Instance.GetEnemy_103(pos, angle) },
            { SpawnType.Enemy104, (pos, angle) => Factory.Instance.GetEnemy_104(pos, angle) },
            { SpawnType.Enemy105, (pos, angle) => Factory.Instance.GetEnemy_105(pos, angle) },
            { SpawnType.Enemy200, (pos, angle) => Factory.Instance.GetEnemy_200(pos, angle) },
            { SpawnType.Enemy201, (pos, angle) => Factory.Instance.GetEnemy_201(pos, angle) },
            { SpawnType.Enemy202, (pos, angle) => Factory.Instance.GetEnemy_202(pos, angle) },
            { SpawnType.Enemy203, (pos, angle) => Factory.Instance.GetEnemy_203(pos, angle) },
            { SpawnType.Enemy204, (pos, angle) => Factory.Instance.GetEnemy_204(pos, angle) },
            { SpawnType.Enemy205, (pos, angle) => Factory.Instance.GetEnemy_205(pos, angle) },
            { SpawnType.Enemy206, (pos, angle) => Factory.Instance.GetEnemy_206(pos, angle) },
            { SpawnType.Enemy207, (pos, angle) => Factory.Instance.GetEnemy_207(pos, angle) },
            { SpawnType.Enemy208, (pos, angle) => Factory.Instance.GetEnemy_208(pos, angle) },
            { SpawnType.Enemy209, (pos, angle) => Factory.Instance.GetEnemy_209(pos, angle) },
            { SpawnType.Enemy210, (pos, angle) => Factory.Instance.GetEnemy_210(pos, angle) },
            { SpawnType.Enemy211, (pos, angle) => Factory.Instance.GetEnemy_211(pos, angle) },
        };

        monsterButton.onClick.AddListener(() => ClickMonsterButton());
    }

    public void ClickMonsterButton()
    {
        spawnMethod[spawnType]?.Invoke(new Vector2(10, 0), 0);
    }
}
