﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Authentication;
    using Models.Carts;
    using PartnerCenter.Models.Carts;
    using Properties;

    /// <summary>
    /// Updates the specified cart.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "PartnerCustomerCart", SupportsShouldProcess = true)]
    [OutputType(typeof(PSCart))]
    public class SetPartnerCustomerCart : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required cart identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the cart.", Mandatory = true)]
        [ValidateNotNull]
        public string CartId { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a collection of cart line items.
        /// </summary>
        [Parameter(HelpMessage = "The line items for the cart.", Mandatory = true)]
        [ValidateNotNull]
        public PSCartLineItem[] LineItems { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.SetPartnerCustomerCartWhatIf, CartId)))
                {
                    IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                    Cart cart;
                    CartLineItem cartLineItem;
                    List<CartLineItem> cartLineItems;

                    cart = await partner.Customers[CustomerId].Carts[CartId].GetAsync(CancellationToken).ConfigureAwait(false);

                    cartLineItems = new List<CartLineItem>();

                    foreach (PSCartLineItem item in LineItems)
                    {
                        cartLineItem = new CartLineItem();
                        cartLineItem.CopyFrom(item);

                        cartLineItems.Add(cartLineItem);
                    }

                    cart.LineItems = cartLineItems;
                    cart = await partner.Customers[CustomerId].Carts[CartId].PutAsync(cart, CancellationToken).ConfigureAwait(false);

                    WriteObject(new PSCart(cart));
                }
            }, true);
        }
    }
}