using Models;

namespace Scripts
{
    public sealed class CheckInstallationScript
    {
        public string Script { get; private set; }

        public CheckInstallationScript(FormViewModel formViewModel)
        {
            Script = @$"IF (dbo.Man_Deploy_CheckInstallation('{formViewModel.InstallationCode}') = 0 )
BEGIN
    PRINT 'The script is not applicable for this installation. Please Continue.'
    RETURN
END";
        }
    }
}