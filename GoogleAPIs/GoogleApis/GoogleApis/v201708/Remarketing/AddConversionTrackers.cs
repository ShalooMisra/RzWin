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
using Google.Api.Ads.AdWords.v201708;

using System;
using System.Collections.Generic;

namespace GmailAPI.Examples.CSharp.v201708 {

  /// <summary>
  /// This code example adds an AdWords conversion tracker and an upload conversion tracker.
  /// </summary>
  public class AddConversionTrackers : ExampleBase {

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void _Main(string[] args) {
      AddConversionTrackers codeExample = new AddConversionTrackers();
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
        return "This code example adds an AdWords conversion tracker and an upload conversion " +
            "tracker.";
      }
    }

    /// <summary>
    /// Runs the code example.
    /// </summary>
    /// <param name="user">The AdWords user.</param>
    public void Run(AdWordsUser user) {
      // Get the ConversionTrackerService.
      ConversionTrackerService conversionTrackerService =
          (ConversionTrackerService)user.GetService(AdWordsService.v201708.
              ConversionTrackerService);

      List<ConversionTracker> conversionTrackers = new List<ConversionTracker>();

      // Create an Adwords conversion tracker.
      AdWordsConversionTracker adWordsConversionTracker = new AdWordsConversionTracker();
      adWordsConversionTracker.name = "Earth to Mars Cruises Conversion #" +
          ExampleUtilities.GetRandomString();
      adWordsConversionTracker.category = ConversionTrackerCategory.DEFAULT;
      adWordsConversionTracker.textFormat = AdWordsConversionTrackerTextFormat.HIDDEN;

      // Set optional fields.
      adWordsConversionTracker.status = ConversionTrackerStatus.ENABLED;
      adWordsConversionTracker.viewthroughLookbackWindow = 15;
      adWordsConversionTracker.conversionPageLanguage = "en";
      adWordsConversionTracker.backgroundColor = "#0000FF";
      adWordsConversionTracker.defaultRevenueValue = 23.41;
      adWordsConversionTracker.alwaysUseDefaultRevenueValue = true;
      conversionTrackers.Add(adWordsConversionTracker);

      // Create an upload conversion for offline conversion imports.
      UploadConversion uploadConversion = new UploadConversion();
      // Set an appropriate category. This field is optional, and will be set to
      // DEFAULT if not mentioned.
      uploadConversion.category = ConversionTrackerCategory.LEAD;
      uploadConversion.name = "Upload Conversion #" + ExampleUtilities.GetRandomString();
      uploadConversion.viewthroughLookbackWindow = 30;
      uploadConversion.ctcLookbackWindow = 90;

      // Optional: Set the default currency code to use for conversions
      // that do not specify a conversion currency. This must be an ISO 4217
      // 3-character currency code such as "EUR" or "USD".
      // If this field is not set on this UploadConversion, AdWords will use
      // the account's currency.
      uploadConversion.defaultRevenueCurrencyCode = "EUR";

      // Optional: Set the default revenue value to use for conversions
      // that do not specify a conversion value. Note that this value
      // should NOT be in micros.
      uploadConversion.defaultRevenueValue = 2.50;

      // Optional: To upload fractional conversion credits, mark the upload conversion
      // as externally attributed. See
      // https://developers.google.com/adwords/api/docs/guides/conversion-tracking#importing_externally_attributed_conversions
      // to learn more about importing externally attributed conversions.

      // uploadConversion.isExternallyAttributed = true;

      conversionTrackers.Add(uploadConversion);

      try {
        // Create operations.
        List<ConversionTrackerOperation> operations = new List<ConversionTrackerOperation>();
        foreach (ConversionTracker conversionTracker in conversionTrackers) {
          operations.Add(new ConversionTrackerOperation() {
            @operator = Operator.ADD,
            operand = conversionTracker
          });
        }

        // Add conversion tracker.
        ConversionTrackerReturnValue retval = conversionTrackerService.mutate(
            operations.ToArray());

        // Display the results.
        if (retval != null && retval.value != null) {
          foreach (ConversionTracker conversionTracker in retval.value) {
            if (conversionTracker is AdWordsConversionTracker) {
              AdWordsConversionTracker newAdWordsConversionTracker =
                  (AdWordsConversionTracker)conversionTracker;
              Console.WriteLine("Conversion with ID {0}, name '{1}', status '{2}', category " +
                  "'{3}' and snippet '{4}' was added.",
                  newAdWordsConversionTracker.id, newAdWordsConversionTracker.name,
                  newAdWordsConversionTracker.status, newAdWordsConversionTracker.category,
                  newAdWordsConversionTracker.snippet);
            } else {
              Console.WriteLine("Conversion with ID {0}, name '{1}', status '{2}' and category " +
                  "'{3}' was added.", conversionTracker.id, conversionTracker.name,
                  conversionTracker.status, conversionTracker.category);
            }
          }
        } else {
          Console.WriteLine("No conversion trackers were added.");
        }
      } catch (Exception e) {
        throw new System.ApplicationException("Failed to add conversion trackers.", e);
      }
    }
  }
}
