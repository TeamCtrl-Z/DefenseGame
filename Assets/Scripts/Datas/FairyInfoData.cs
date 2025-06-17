/// <summary>
/// 페어리 정보 관련 CSV파일 로드 클래스
/// </summary>
public class FairyInfoData
{
    /// <summary>
    /// 페어리 타입
    /// </summary>
    public uint FID;

    /// <summary>
    /// 페어리 이름
    /// </summary>
    public string Name;

    /// <summary>
    /// 페어리 등급
    /// </summary>
    public FairyGrade Grade;

    /// <summary>
    /// 페어리 인 게임 이미지 주소
    /// </summary>
    public string Image_1;

    /// <summary>
    /// 페어리 일러스트 이미지 주소
    /// </summary>
    public string Image_2;

    /// <summary>
    /// 페어리 설명
    /// </summary>
    public string Desc;
}