using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Enums
{
    internal class Enums
    {
        internal enum pathsToCheck
        {
            ExcelFilePath,
            SqlExportFilePath
        }

        internal enum intOrBlankFields
        {
            InstallationCode
        }

        internal enum nonNullableNonEmptyStringFields
        {
            LovtDesc,
            LovtComments
        }

        internal enum nullableIntFields
        {
            LovLow,
            LovHigh,
            LovCodeParent,
            LovPriority,
            LovAggregatedPriority
        }

        internal enum nullableNonEmptyStringFields
        {
            LovSId,
            LovSource,
            LovGroup
        }

        internal enum oneZeroOrNullFields
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
