using System;
using System.Collections.Generic;

#nullable disable

namespace PJ_Login.Models
{
    public partial class Output
    {
        public string Month { get; set; }
        public byte Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Device { get; set; }
        public DateTime? Date2 { get; set; }
        public TimeSpan? Time2 { get; set; }
        public string DevName { get; set; }
        public string DevId { get; set; }
        public long? EventTime { get; set; }
        public string TimeZone { get; set; }
        public int LogId { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string EventType { get; set; }
        public bool? Level { get; set; }
        public string VirtualDomain { get; set; }
        public string Severity { get; set; }
        public string SrcIp { get; set; }
        public int? SrcPort { get; set; }
        public string SrcInterface { get; set; }
        public string SrcInterfaceRole { get; set; }
        public string DstIp { get; set; }
        public int? DstPort { get; set; }
        public string DstInterface { get; set; }
        public string DstInterfaceRole { get; set; }
        public string SrcCountry { get; set; }
        public string DstCountry { get; set; }
        public long? SessionId { get; set; }
        public byte? Proto { get; set; }
        public string Action { get; set; }
        public byte  PolicyId { get; set; }
        public string PolicyType { get; set; }
        public string PolicyUuid { get; set; }
        public string Service { get; set; }
        public string Trandisp { get; set; }
        public string ApplicationCategory { get; set; }
        public string ApplicationList { get; set; }
        public int? Duration { get; set; }
        public int? SentByte { get; set; }
        public int? RecoveredByte { get; set; }
        public int? SentPkt { get; set; }
        public int? RecoveredPkt { get; set; }
        public string Direction { get; set; }
        public string Attack { get; set; }
        public string AttackId { get; set; }
        public string Profile { get; set; }
        public string TransactionId { get; set; }
        public string QueryName { get; set; }
        public string QueryType { get; set; }
        public string QueryTypeValue { get; set; }
        public string QueryClass { get; set; }
        public string Error { get; set; }
        public string ResponseCode { get; set; }
        public string Reference { get; set; }
        public string Incidentserialno { get; set; }
        public string Message { get; set; }
        public byte? CoreRuleSetScore { get; set; }
        public int? CoreRuleAction { get; set; }
        public string CoreRuleLevel { get; set; }
        public string LogDescription { get; set; }
    }
}
