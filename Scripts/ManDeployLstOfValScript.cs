using Models;

namespace Scripts
{
    public sealed class ManDeployLstOfValScript
    {
		public string Script { get; private set; }
		public ManDeployLstOfValScript(FormViewModel formViewModel)
        {
            Script = @$"SET @LOV_INTERNAL_DESC = N'{formViewModel.LovInternalDesc}'

IF NOT EXISTS (SELECT LOV_CODE
				FROM dbo.AT_LST_OF_VAL 
				WHERE LOV_INTERNAL_DESC = @LOV_INTERNAL_DESC
				AND LOVT_CODE = (SELECT LOVT_CODE FROM AT_LOV_TYPES WHERE LOVT_DESC = @LOVT_DESC))
BEGIN

-- LOVS --

EXEC Man_Deploy_Lst_Of_Val 
	@inst_code = '{formViewModel.InstallationCode}',
	@update_if_exists = {formViewModel.UpdateIfExistsLstOfVal},
	@lovt_desc = '{formViewModel.LovtDesc}',
	@lov_internal_desc = '{formViewModel.LovInternalDesc}',
	@lov_internal = {formViewModel.LovInternal},
	@lov_code_parent = {formViewModel.LovCodeParent},
	@lov_desc = '{formViewModel.LovDesc}',
	@lov_active = {formViewModel.LovActive},   
	@lov_low = {formViewModel.LovLow},
	@lov_high = {formViewModel.LovHigh},
	@lov_comments = '{formViewModel.LovComments}',
	@lov_is_submitted = {formViewModel.LovIsSubmitted},
	@lov_is_approved = {formViewModel.LovIsApproved},
	@lov_is_rejected = {formViewModel.LovIsRejected},
	@lov_is_completed = {formViewModel.LovIsCompleted},
	@lov_is_cancelled = {formViewModel.LovIsCancelled},
	@lov_s_id = {formViewModel.LovSId},
	@lov_source = {formViewModel.LovSource},
	@lov_group = {formViewModel.LovGroup},
	@lov_retype_pass = {formViewModel.LovRetypePass},
	@lov_is_out_of_collection = {formViewModel.LovIsOutOfCollection},
	@lov_is_approval_level = {formViewModel.LovIsApprovalLevel},
	@lov_is_settlement_activate = {formViewModel.LovIsSettlementActivate},
	@lov_is_settlement_cancel = {formViewModel.LovIsSettlementCancel},
	@lov_priority = {formViewModel.LovPriority},
	@lov_is_analytics_end = {formViewModel.LovIsAnalyticsEnd},
	@lov_is_activated = {formViewModel.LovIsActivated},
	@lov_long_desc = '{formViewModel.LovLongDesc}',
	@lov_is_locked = {formViewModel.LovIsLocked},
	@lov_is_lock_properties = {formViewModel.LovIsLockProperties},
	@lov_aggregated_priority = {formViewModel.LovAggregatedPriority},
	@lov_is_eod = {formViewModel.LovIsEod}

END";
        }
    }
}
