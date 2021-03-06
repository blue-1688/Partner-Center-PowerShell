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
    using Newtonsoft.Json;

    /// <summary>
    /// Details of the product to be transferred.
    /// </summary>
    public partial class ProductDetails
    {
        /// <summary>
        /// Initializes a new instance of the ProductDetails class.
        /// </summary>
        public ProductDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ProductDetails class.
        /// </summary>
        /// <param name="productType">Type of the product to be transferred.
        /// Possible values include: 'AzureSubscription',
        /// 'AzureReservation'</param>
        /// <param name="productId">Id of product to be transferred.</param>
        public ProductDetails(string productType = default(string), string productId = default(string))
        {
            ProductType = productType;
            ProductId = productId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets type of the product to be transferred. Possible values
        /// include: 'AzureSubscription', 'AzureReservation'
        /// </summary>
        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets id of product to be transferred.
        /// </summary>
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }

    }
}
