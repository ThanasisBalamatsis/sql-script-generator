namespace Models
{
    public sealed class FormViewModel
    {
        #region LovTypeConfigurationProperties
        public string InstallationCode { get; set; }
        public string LovtDesc { get; set; }
        public string UpdateIfExistsLovType { get; set; }
        public string LovtComments { get; set; }
        public string LovtInternal { get; set; }
        public string LovtUpdateAllowed { get; set; }
        public string LovtUpdateTransAllowed { get; set; }
        public string LovtAllowGlobal { get; set; }
        public string LovtAllowGroup { get; set; }
        public string LovtUpdatePriorityAllowed { get; set; }
        public string LovtIsLegal { get; set; }
        public string LovtForSettlementFlag { get; set; }
        public string LovtHasLongDescriptionFlag { get; set; }
        public string LovtUpdateAggregatedPriorityAllowed { get; set; }
        public string LovLow { get; set; }
        public string LovHigh { get; set; }
        public string? LovSId { get; set; }
        public string? LovSource { get; set; }
        public string? LovGroup { get; set; }
        public string LovtIsLocked { get; set; }
        public string InsertNAValue { get; set; }
        #endregion

        #region LstOfValConfigurationProperties
        public string UpdateIfExistsLstOfVal { get; set; }
        public string LovInternal { get; private set; }
        public string LovCodeParent { get; set; }
        public string LovActive { get; private set; }
        public string LovIsSubmitted { get; set; }
        public string LovIsApproved { get; set; }
        public string LovIsRejected { get; set; }
        public string LovIsCompleted { get; set; }
        public string LovIsCancelled { get; set; }
        public string LovRetypePass { get; set; }
        public string LovIsOutOfCollection { get; set; }
        public string LovIsApprovalLevel { get; set; }
        public string LovIsSettlementActivate { get; set; }
        public string LovIsSettlementCancel { get; set; }
        public string LovPriority { get; set; }
        public string LovIsAnalyticsEnd { get; set; }
        public string LovIsActivated { get; set; }
        public string LovIsLocked { get; set; }
        public string LovIsLockProperties { get; set; }
        public string LovAggregatedPriority { get; set; }
        public string LovIsEod { get; set; }
        #endregion

        #region PathProperties
        public string ExcelFilePath { get; set; }
        public string SqlExportFilePath { get; set; }
        #endregion

        #region ExtraFieldsNotInUI
        public string LovDesc { get; set; }
        public string LovComments { get; set; }
        public string LovLongDesc { get; set; }
        public string LovInternalDesc { get; set; }
        #endregion
    }
}