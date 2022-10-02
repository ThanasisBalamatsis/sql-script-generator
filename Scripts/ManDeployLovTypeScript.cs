using Models;

namespace Scripts
{
    public sealed class ManDeployLovTypeScript
    {
		public string Script { get; private set; }
		public ManDeployLovTypeScript(FormViewModel formViewModel)
        {
            Script = @$"BEGIN

-- LOV_TYPES --

EXEC dbo.Man_Deploy_LovType 
	@inst_code = N'{formViewModel.InstallationCode}',	
	@lovt_desc = N'{formViewModel.LovtDesc}',	
	@update_if_exists = {formViewModel.UpdateIfExistsLovType},	
	@lovt_comments =  N'{formViewModel.LovtComments}'	,	
	@lovt_internal = {formViewModel.LovtInternal}	,	
	@lovt_update_allowed = {formViewModel.LovtUpdateAllowed} ,
	@lovt_update_trans_allowed = {formViewModel.LovtUpdateTransAllowed} ,		
	@lovt_allow_global = {formViewModel.LovtAllowGlobal}	,	
	@lovt_allow_group = {formViewModel.LovtAllowGroup} ,	
	@lovt_update_priority_allowed = {formViewModel.LovtUpdatePriorityAllowed} ,	
	@lovt_is_legal = {formViewModel.LovtIsLegal} ,	
	@lovt_for_settlement_flag = {formViewModel.LovtForSettlementFlag} ,	
	@lovt_has_long_description_flag	= {formViewModel.LovtHasLongDescriptionFlag} ,	
	@lovt_update_aggregated_priority_allowed = {formViewModel.LovtUpdateAggregatedPriorityAllowed} ,	
	@lov_low = {formViewModel.LovLow} ,	
	@lov_high = {formViewModel.LovHigh} ,	
	@lov_s_id = {formViewModel.LovSId} ,	
	@lov_source = {formViewModel.LovSource} ,	
	@lov_group = {formViewModel.LovGroup} ,	
	@lov_is_locked = {formViewModel.LovIsLocked} ,	
	@insert_NA_value = {formViewModel.InsertNAValue} ,      
	@lovt_stmdl_desc = '{formViewModel.LovtDesc}'
END";
        }
    }
}
