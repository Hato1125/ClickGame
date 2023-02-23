namespace ClickGame;

internal interface IResourceManageable
{
    /// <summary>
    /// リソースを登録する
    /// </summary>
    /// <param name="resourceName">リソースの名前</param>
    /// <param name="fileName">ファイル名</param>
    void AddResource(string resourceName ,string fileName);

    /// <summary>
    /// リソースを削除する
    /// </summary>
    /// <param name="resourceName">リソースの名前</param>
    void RemoveResource(string resourceName);

    /// <summary>
    /// リソースをすべて削除する
    /// </summary>
    void RemoveAllResource();

    /// <summary>
    /// リソースを取得する
    /// </summary>
    /// <param name="resourceName">リソースの名前</param>
    object GetResource(string resourceName);
}