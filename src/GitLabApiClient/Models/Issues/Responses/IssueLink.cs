using Newtonsoft.Json;
using GitLabApiClient.Models.Issues.Requests;
namespace GitLabApiClient.Models.Issues.Responses
{
    public sealed class IssueLink
    {
        [JsonProperty("source_issue")]
        public Issue SourceIssue { get; set; }

        [JsonProperty("target_issue")]
        public Issue TargetIssue { get; set; }

        [JsonProperty("link_type")]
        public IssueLinkTypeEnum LinkType { get; set; }
    }
}
