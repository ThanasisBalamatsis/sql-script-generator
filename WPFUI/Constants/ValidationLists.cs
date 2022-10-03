using System.Collections.Generic;

namespace WPFUI.Constants
{
    internal static class ValidationLists
    {
        internal static readonly List<string> pathsToCheck = new List<string> { "ExcelFilePath", "SqlExportFilePath" };
        internal static readonly List<string> intOrBlankFields = new List<string> { "InstallationCode" };
        internal static readonly List<string> nonNullableNonEmptyStringFields = new List<string> { "LovtDesc", "LovtComments" };
        internal static readonly List<string> nullableIntFields = new List<string> { "LovLow", "LovHigh", "LovCodeParent", "LovPriority", "LovAggregatedPriority" };
        internal static readonly List<string> nullableNonEmptyStringFields = new List<string> { "LovSId", "LovSource", "LovGroup" };
        internal static readonly List<string> oneZeroOrNullFields = new List<string> { "LovRetypePass", 
                                                                                     "LovIsOutOfCollection", 
                                                                                     "LovIsApprovalLevel", 
                                                                                     "LovIsSettlementActivate",
                                                                                     "LovIsSettlementCancel", 
                                                                                     "LovIsAnalyticsEnd", 
                                                                                     "LovIsActivated", 
                                                                                     "LovIsLocked", 
                                                                                     "LovIsLockProperties", 
                                                                                     "LovIsEod"};
    }
}
