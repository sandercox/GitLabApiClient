using System.Runtime.Serialization;

namespace GitLabApiClient.Models.Issues.Requests
{
    public enum IssueLinkTypeEnum
    {
        [EnumMember(Value = "relates_to")]
        RelatesTo,
        [EnumMember(Value = "blocks")]
        Blocks,
        [EnumMember(Value = "is_blocked_by")]
        IsBlockedBy
    }
}
