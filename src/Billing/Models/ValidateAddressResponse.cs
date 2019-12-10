// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Billing.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Result of the address validation
    /// </summary>
    public partial class ValidateAddressResponse
    {
        /// <summary>
        /// Initializes a new instance of the ValidateAddressResponse class.
        /// </summary>
        public ValidateAddressResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ValidateAddressResponse class.
        /// </summary>
        /// <param name="status">status of the address validation. Possible
        /// values include: 'Valid', 'Invalid'</param>
        /// <param name="suggestedAddresses">list of suggested
        /// addresses.</param>
        /// <param name="validationMessage">Validation error message.</param>
        public ValidateAddressResponse(string status = default(string), IList<AddressDetails> suggestedAddresses = default(IList<AddressDetails>), string validationMessage = default(string))
        {
            Status = status;
            SuggestedAddresses = suggestedAddresses;
            ValidationMessage = validationMessage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets status of the address validation. Possible values
        /// include: 'Valid', 'Invalid'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets list of suggested addresses.
        /// </summary>
        [JsonProperty(PropertyName = "suggestedAddresses")]
        public IList<AddressDetails> SuggestedAddresses { get; set; }

        /// <summary>
        /// Gets or sets validation error message.
        /// </summary>
        [JsonProperty(PropertyName = "validationMessage")]
        public string ValidationMessage { get; set; }

    }
}