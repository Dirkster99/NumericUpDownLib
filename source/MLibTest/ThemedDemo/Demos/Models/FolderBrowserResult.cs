namespace ThemedDemo.Demos.Models
{
    public class FolderBrowserResult
    {
        #region constructors
        public FolderBrowserResult()
        {
            this.Path = default(string);
            this.Result = null;
        }
        #endregion constructors

        #region properties
        public string Path { get; private set; }

        public bool? Result { get; private set; }
        #endregion properties

        #region methods
        public void SetResult(bool result)
        {
            this.Result = result;
        }

        public void SetPath(string path)
        {
            if (string.IsNullOrEmpty(path) == false)
                Path = path;
            else
                Path = default(string);
        }
        #endregion methods
    }
}
