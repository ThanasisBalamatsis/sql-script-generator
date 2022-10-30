using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Enums
{
    internal class Enums
    {
        public enum pathsToCheck
        {
            ExcelFilePath,
            SqlExportFilePath
        }

        public enum intOrBlankFields
        {
            InstallationCode
        }

        public enum nonNullableNonEmptyStringFields
        {
            LovtDesc,
            LovtComments
        }

        public enum nullableIntFields
        {
            LovLow,
            LovHigh,
            LovCodeParent,
            LovPriority,
            LovAggregatedPriority
        }

        public enum nullableNonEmptyStringFields
        {
            LovSId,
            LovSource,
            LovGroup
        }

        public enum oneZeroOrNullFields
        {
            LovRetypePass,
            LovIsOutOfCollection,
            LovIsApprovalLevel,
            LovIsSettlementActivate,
            LovIsSettlementCancel,
            LovIsAnalyticsEnd,
            LovIsActivated,
            LovIsLocked,
            LovIsLockProperties,
            LovIsEod
        }
    }
}
