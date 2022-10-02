using Models;

namespace Scripts
{
    public sealed class SelectScript
    {
        public string Script { get; private set; }

        public SelectScript(FormViewModel formViewModel)
        {
            Script = @$"select * from at_lov_types where lovt_desc = '{formViewModel.LovtDesc}'
select * from at_lst_of_val where lovt_code = (select lovt_code from at_lov_types where lovt_desc = '{formViewModel.LovtDesc}')";

        }
    }
}
