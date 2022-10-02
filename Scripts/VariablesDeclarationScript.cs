using Models;

namespace Scripts
{
    public sealed class VariablesDeclarationScript
    {
        public string Script { get; private set; }

        public VariablesDeclarationScript(FormViewModel formViewModel)
        {
            Script = $@"DECLARE @LOVT_DESC NVARCHAR(100);
DECLARE @LOV_INTERNAL_DESC NVARCHAR(100);

SET @LOVT_DESC = N'{formViewModel.LovtDesc}'";
        }
    }
}
