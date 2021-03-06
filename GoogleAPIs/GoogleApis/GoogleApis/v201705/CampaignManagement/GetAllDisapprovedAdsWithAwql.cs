// Copyright 2017, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201705;

using System;

namespace GmailAPI.Examples.CSharp.v201705 {

  /// <summary>
  /// This code example retrieves all the disapproved ads in a given campaign
  /// using AWQL. See https://developers.google.com/adwords/api/docs/guides/awql
  /// for AWQL documentation.
  /// </summary>
  public class GetAllDisapprovedAdsWithAwql : ExampleBase {

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void _Main(string[] args) {
      GetAllDisapprovedAdsWithAwql codeExample = new GetAllDisapprovedAdsWithAwql();
      Console.WriteLine(codeExample.Description);
      try {
        long campaignId = long.Parse("INSERT_CAMPAIGN_ID_HERE");
        codeExample.Run(new AdWordsUser(), campaignId);
      } catch (Exception e) {
        Console.WriteLine("An exception occurred while running this code example. {0}",
            ExampleUtilities.FormatException(e));
      }
    }

    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example retrieves all the disapproved ads in a given campaign using " +
            "AWQL. See https://developers.google.com/adwords/api/docs/guides/awql for AWQL " +
            "documentation.";
      }
    }

    /// <summary>
    /// Runs the code example.
    /// </summary>
    /// <param name="user">The AdWords user.</param>
    /// <param name="campaignId">Id of the campaign for which disapproved ads
    /// are retrieved.</param>
    public void Run(AdWordsUser user, long campaignId) {
      // Get the AdGroupAdService.
      AdGroupAdService service =
          (AdGroupAdService) user.GetService(AdWordsService.v201705.AdGroupAdService);

      // Get all the disapproved ads for this campaign.
      string query = string.Format("SELECT Id, PolicySummary WHERE CampaignId = {0} and " +
          "CombinedApprovalStatus = DISAPPROVED ORDER BY Id", campaignId);

      int offset = 0;
      int pageSize = 500;

      AdGroupAdPage page = new AdGroupAdPage();
      int disapprovedAdsCount = 0;

      try {
        do {
          string queryWithPaging = string.Format("{0} LIMIT {1}, {2}", query, offset, pageSize);

          // Get the disapproved ads.
          page = service.query(queryWithPaging);

          // Display the results.
          if (page != null && page.entries != null) {
            foreach (AdGroupAd adGroupAd in page.entries) {
              AdGroupAdPolicySummary policySummary = adGroupAd.policySummary;
              disapprovedAdsCount++;
              Console.WriteLine("Ad with ID {0} and type '{1}' was disapproved with the " +
                  "following policy topic entries: ", adGroupAd.ad.id, adGroupAd.ad.AdType);
              foreach (PolicyTopicEntry policyTopicEntry in policySummary.policyTopicEntries) {
                Console.WriteLine("  topic id: {0}, topic name: '{1}'",
                    policyTopicEntry.policyTopicId, policyTopicEntry.policyTopicName);
              }
            }
          }
          offset += pageSize;
        } while (offset < page.totalNumEntries);

        Console.WriteLine("Number of disapproved ads found: {0}", disapprovedAdsCount);
      } catch (Exception e) {
        throw new System.ApplicationException("Failed to get disapproved ads.", e);
      }
    }
  }
}
