// Copyright 2016, Google Inc. All Rights Reserved.
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
using Google.Api.Ads.AdWords.v201609;

using System;
using System.Collections.Generic;

namespace GmailAPI.Examples.CSharp.v201609 {

  /// <summary>
  /// This code example adds a universal app campaign. To get campaigns, run GetCampaigns.cs.
  /// To upload image assets for this campaign, use UploadImage.cs.
  /// </summary>
  public class AddUniversalAppCampaign : ExampleBase {

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void _Main(string[] args) {
      AddUniversalAppCampaign codeExample = new AddUniversalAppCampaign();
      Console.WriteLine(codeExample.Description);
      try {
        codeExample.Run(new AdWordsUser());
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
        return "This code example adds a universal app campaign. To get campaigns, run " +
            "GetCampaigns.cs. To upload image assets for this campaign, use UploadImage.cs.";
      }
    }

    /// <summary>
    /// Runs the code example.
    /// </summary>
    /// <param name="user">The AdWords user.</param>
    public void Run(AdWordsUser user) {
      // Get the CampaignService.
      CampaignService campaignService =
        (CampaignService) user.GetService(AdWordsService.v201609.CampaignService);

      // Create the campaign.
      Campaign campaign = new Campaign();
      campaign.name = "Interplanetary Cruise App #" + ExampleUtilities.GetRandomString();

      // Recommendation: Set the campaign to PAUSED when creating it to prevent
      // the ads from immediately serving. Set to ENABLED once you've added
      // targeting and the ads are ready to serve.
      campaign.status = CampaignStatus.PAUSED;

      // Set the advertising channel and subchannel types for universal app campaigns.
      campaign.advertisingChannelType = AdvertisingChannelType.MULTI_CHANNEL;
      campaign.advertisingChannelSubType = AdvertisingChannelSubType.UNIVERSAL_APP_CAMPAIGN;

      // Set the campaign's bidding strategy. Universal app campaigns
      // only support TARGET_CPA bidding strategy.
      BiddingStrategyConfiguration biddingConfig = new BiddingStrategyConfiguration();
      biddingConfig.biddingStrategyType = BiddingStrategyType.TARGET_CPA;

      // Set the target CPA to $1 / app install.
      TargetCpaBiddingScheme biddingScheme = new TargetCpaBiddingScheme();
      biddingScheme.targetCpa = new Money();
      biddingScheme.targetCpa.microAmount = 1000000;

      biddingConfig.biddingScheme = biddingScheme;
      campaign.biddingStrategyConfiguration = biddingConfig;

      // Set the campaign's budget.
      campaign.budget = new Budget();
      campaign.budget.budgetId = CreateBudget(user).budgetId;

      // Optional: Set the start date.
      campaign.startDate = DateTime.Now.AddDays(1).ToString("yyyyMMdd");

      // Optional: Set the end date.
      campaign.endDate = DateTime.Now.AddYears(1).ToString("yyyyMMdd");

      // Set the campaign's assets and ad text ideas. These values will be used to
      // generate ads.
      UniversalAppCampaignSetting universalAppSetting = new UniversalAppCampaignSetting();
      universalAppSetting.appId = "com.labpixies.colordrips";
      universalAppSetting.description1 = "Best Space Cruise Line";
      universalAppSetting.description2 = "Visit all the planets";
      universalAppSetting.description3 = "Trips 7 days a week";
      universalAppSetting.description4 = "Buy your tickets now!";

      // Optional: You can set up to 10 image assets for your campaign.
      // See UploadImage.cs for an example on how to upload images.
      //
      // universalAppSetting.imageMediaIds = new long[] { INSERT_IMAGE_MEDIA_ID_HERE };

      // Optimize this campaign for getting new users for your app.
      universalAppSetting.universalAppBiddingStrategyGoalType =
          UniversalAppBiddingStrategyGoalType.OPTIMIZE_FOR_INSTALL_CONVERSION_VOLUME;

      // Optional: If you select the OPTIMIZE_FOR_IN_APP_CONVERSION_VOLUME goal
      // type, then also specify your in-app conversion types so AdWords can
      // focus your campaign on people who are most likely to complete the
      // corresponding in-app actions.
      // Conversion type IDs can be retrieved using ConversionTrackerService.get.
      //
      // campaign.selectiveOptimization = new SelectiveOptimization();
      // campaign.selectiveOptimization.conversionTypeIds =
      //    new long[] { INSERT_CONVERSION_TYPE_ID_1_HERE, INSERT_CONVERSION_TYPE_ID_2_HERE };

      // Optional: Set the campaign settings for Advanced location options.
      GeoTargetTypeSetting geoSetting = new GeoTargetTypeSetting();
      geoSetting.positiveGeoTargetType =
          GeoTargetTypeSettingPositiveGeoTargetType.LOCATION_OF_PRESENCE;
      geoSetting.negativeGeoTargetType =
          GeoTargetTypeSettingNegativeGeoTargetType.DONT_CARE;

      campaign.settings = new Setting[] { universalAppSetting, geoSetting };

      // Create the operation.
      CampaignOperation operation = new CampaignOperation();
      operation.@operator = Operator.ADD;
      operation.operand = campaign;

      try {
        // Add the campaign.
        CampaignReturnValue retVal = campaignService.mutate(new CampaignOperation[] { operation });

        // Display the results.
        if (retVal != null && retVal.value != null && retVal.value.Length > 0) {
          foreach (Campaign newCampaign in retVal.value) {
            Console.WriteLine("Universal app campaign with name = '{0}' and id = '{1}' was added.",
                newCampaign.name, newCampaign.id);

            // Optional: Set the campaign's location and language targeting. No other targeting
            // criteria can be used for universal app campaigns.
            SetCampaignTargetingCriteria(user, newCampaign);
          }
        } else {
          Console.WriteLine("No universal app campaigns were added.");
        }
      } catch (Exception e) {
        throw new System.ApplicationException("Failed to add universal app campaigns.", e);
      }
    }

    /// <summary>
    /// Creates the budget for the campaign.
    /// </summary>
    /// <param name="user">The AdWords user.</param>
    /// <returns>The budget.</returns>
    private Budget CreateBudget(AdWordsUser user) {
      // Get the BudgetService.
      BudgetService budgetService =
        (BudgetService) user.GetService(AdWordsService.v201609.BudgetService);

      // Create the campaign budget.
      Budget budget = new Budget();
      budget.name = "Interplanetary Cruise App Budget #" + ExampleUtilities.GetRandomString();
      budget.deliveryMethod = BudgetBudgetDeliveryMethod.STANDARD;
      budget.amount = new Money();
      budget.amount.microAmount = 5000000;

      // Universal app campaigns don't support shared budgets.
      budget.isExplicitlyShared = false;

      BudgetOperation budgetOperation = new BudgetOperation();
      budgetOperation.@operator = Operator.ADD;
      budgetOperation.operand = budget;

      BudgetReturnValue budgetRetval = budgetService.mutate(
        new BudgetOperation[] { budgetOperation });
      Budget newBudget = budgetRetval.value[0];

      Console.WriteLine("Budget with ID = '{0}' and name = '{1}' was created.",
          newBudget.budgetId, newBudget.name);
      return newBudget;
    }

    /// <summary>
    /// Sets the campaign's targeting criteria.
    /// </summary>
    /// <param name="user">The AdWords user.</param>
    /// <param name="campaign">The campaign for which targeting criteria is
    /// created.</param>
    private void SetCampaignTargetingCriteria(AdWordsUser user, Campaign campaign) {
      // Get the CampaignCriterionService.
      CampaignCriterionService campaignCriterionService =
        (CampaignCriterionService) user.GetService(
          AdWordsService.v201609.CampaignCriterionService);

      // Create locations. The IDs can be found in the documentation or
      // retrieved with the LocationCriterionService.
      Location california = new Location() {
        id = 21137L
      };

      Location mexico = new Location() {
        id = 2484L
      };

      // Create languages. The IDs can be found in the documentation or
      // retrieved with the ConstantDataService.
      Language english = new Language() {
        id = 1000L
      };

      Language spanish = new Language() {
        id = 1003L
      };

      List<Criterion> criteria = new List<Criterion>() {
        california, mexico, english, spanish };

      // Create operations to add each of the criteria above.
      List<CampaignCriterionOperation> operations = new List<CampaignCriterionOperation>();
      foreach (Criterion criterion in criteria) {
        CampaignCriterionOperation operation = new CampaignCriterionOperation() {
          operand = new CampaignCriterion() {
            campaignId = campaign.id,
            criterion = criterion
          },
          @operator = Operator.ADD
        };

        operations.Add(operation);
      }

      // Set the campaign targets.
      CampaignCriterionReturnValue retVal = campaignCriterionService.mutate(operations.ToArray());

      if (retVal != null && retVal.value != null) {
        // Display the added campaign targets.
        foreach (CampaignCriterion criterion in retVal.value) {
          Console.WriteLine("Campaign criteria of type '{0}' and id '{1}' was added.",
                            criterion.criterion.CriterionType, criterion.criterion.id);
        }
      }
    }
  }
}
